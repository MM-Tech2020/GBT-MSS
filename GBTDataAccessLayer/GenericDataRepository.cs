using GBTDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel
{
    public class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {

        public IList<T> Add(List<T> items)
        {
            using (var context = new GBTMembershipSolutionEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Added;
                }

                context.SaveChanges();
            }
            return items;
        }

        public IList<T> Update(List<T> items)
        {
            using (var context = new GBTMembershipSolutionEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Modified;
                }

                context.SaveChanges();
            }

            return items;
        }

        public IList<T> Remove(List<T> items)
        { 
            using (var context = new GBTMembershipSolutionEntities())
            {
                foreach (T item in items)
                {
                    context.Entry(item).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
            return items;
        }

        public IList<T> GetAll(List<Expression<Func<T, object>>> navigationProperties)
        {

            
            List<T> list;
            using (var context = new GBTMembershipSolutionEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;
                IQueryable<T> dbQuery = context.Set<T>();


                // get custome T wheres
                List<Expression<Func<T, bool>>> customeWheres = GetWheres();

                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in customeWheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);



                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().ToList<T>();
                return list;

            }
        }

        public IList<T> GetList(Func<T, bool> where, List<Expression<Func<T, object>>> navigationProperties)
        {
            List<T> list;
            using (var context = new GBTMembershipSolutionEntities())
            {
                context.Configuration.LazyLoadingEnabled = false;

                IQueryable<T> dbQuery = context.Set<T>();

                // get custome T wheres
                List<Expression<Func<T, bool>>> customeWheres = this.GetWheres();

                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in customeWheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);



                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);

                list = dbQuery.AsNoTracking().Where(where).ToList<T>();
                return list;

            }
        }

        public IList<T> GetLists(List<Expression<Func<T, bool>>> wheres)
        {

            List<T> list;
            using (var context = new GBTMembershipSolutionEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                // get custome T wheres
                List<Expression<Func<T, bool>>> customeWheres = this.GetWheres();

                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in customeWheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);


                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in wheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);


                list = dbQuery.ToList<T>();
                return list;

            }
        }


        public IList<T> GetAllLists(List<Expression<Func<T, bool>>> wheres, List<Expression<Func<T, object>>> navigationProperties)
        {

            List<T> list;
            using (var context = new GBTMembershipSolutionEntities())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                // get custome T wheres
                List < Expression < Func < T, bool>>>  customeWheres = this.GetWheres();

                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in customeWheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);


                //Apply eager loading
                foreach (Expression<Func<T, bool>> wh in wheres)
                    dbQuery = dbQuery.AsNoTracking<T>().Where(wh);

                //Apply eager loading
                foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<T, object>(navigationProperty);



                list = dbQuery.ToList<T>();
                return list;

            }
        }



        /**
         * case of ID is type of long
         **/
        public T GetByID(long ID)
        {
            // get navigation properties of current T
            List<Expression<Func<T, object>>> navigationProperties = this.GetNavigationProperties();
            // where for id match condition 
            Func<T, bool> where   ; 
            
            // get ID of Type T where TID is EntityID
            string TID = typeof(T).Name + "ID";
            
            
            //get id type to be used in cast
            Type t = typeof(T).GetProperty(TID).PropertyType;
           
            
            // case id type is long
            if (t == typeof(long))
            {
                where = x => (long)x.GetType().GetProperty(TID).GetValue(x, null) == ID;
            }
            // case id type is int
            else 
            {
                where = x => (int)x.GetType().GetProperty(TID).GetValue(x, null) == ID;
            }

            IList<T> resultSet = this.GetList(where, navigationProperties);
            
            // check empty result
            if(resultSet.Count == 0 )
                return null;
            else
                return resultSet[0];
        }


        // get navigation properties
        // this virtual function you need to override it foreach child
        public virtual  List<Expression<Func<T, object>>> GetNavigationProperties()
        {
            List<Expression<Func<T, object>>> navigationProperties = new List<Expression<Func<T, object>>>();
            // include navigation properties
            return navigationProperties;
        }



        // include custome where form object 
        // this manly used if T of multible types 
        // EX: User have Type of Doctor
        // on Doctor class override thid method and add condition match only doctor type 
        public virtual  List<Expression<Func<T, bool>>> GetWheres()
        {
            List<Expression<Func<T, bool>>> wheres = new List<Expression<Func<T, bool>>>();
            // include wheres
            return wheres;
        }

    }
}
