using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using SSO.Model;
namespace SSO.DataAccessLayer
{
public abstract class GenericDataRepository<TEntity> : IGenericDataRepository<TEntity> where TEntity : class
{
    private SSOContext _context;
	protected DbSet<TEntity> _dbSet;

    protected GenericDataRepository(SSOContext entitycontext)
    {
        _context = entitycontext;
		_dbSet = _context.Set<TEntity>();
    }

    public IList<TEntity> Add(List<TEntity> items)
        {
            
                foreach (TEntity item in items)
                {
                    _context.Entry(item).State = EntityState.Added;
                }

                //_context.SaveChanges();
            
            return items;
        }
		public void Add(TEntity item)
        {
            _dbSet.Add(item);
            //_context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            //_context.SaveChanges();
        }

        public IList<TEntity> Update(List<TEntity> items)
        {
            
                foreach (TEntity item in items)
                {
                    _context.Entry(item).State = EntityState.Modified;
                }

                //_context.SaveChanges();
            

            return items;
        }

        public IList<TEntity> Remove(IList<TEntity> items)
        { 
		        
                foreach (TEntity item in items)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }

                //_context.SaveChanges();
            return items;
        }

        public IList<TEntity> GetAll(List<Expression<Func<TEntity, object>>> navigationProperties)
        {
            List<TEntity> list;           
                IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

                //Apply eager loading
                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                list = dbQuery.AsNoTracking().ToList<TEntity>();
                return list;

        
        }

        public IList<TEntity> GetList(Func<TEntity, bool> where, List<Expression<Func<TEntity, object>>> navigationProperties)
        {
            List<TEntity> list;
            
                IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

                //Apply eager loading
                foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                    dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

                list = dbQuery.AsNoTracking().Where(where).ToList<TEntity>();
                return list;

           
        }

        public IList<TEntity> GetLists(List< Expression<Func<TEntity, bool>>> wheres)
        {

            List<TEntity> list;
                IQueryable<TEntity> dbQuery = _context.Set<TEntity>();

                //Apply eager loading
                foreach (Expression<Func<TEntity, bool>> wh in wheres)
                    dbQuery = dbQuery.AsNoTracking<TEntity>().Where(wh);


                list = dbQuery.ToList<TEntity>();
                return list;           
        }

        /**
         * Cannot GetByID as we have diffrent IDs names
         **/
        /*public TEntity GetByID(int ID)
        {
            throw new NotImplementedException();
        }*/


        // get navigation properties
        public List<Expression<Func<TEntity, object>>> GetNavigationProperties()
        {
            List<Expression<Func<TEntity, object>>> navigationProperties = new List<Expression<Func<TEntity, object>>>();
            // include navigation properties
            return navigationProperties;
        }

		public IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
        public TEntity FindOne(Func<TEntity, bool> condition)
        {
            return _dbSet.FirstOrDefault(condition);
        }

        public IList<TEntity> FindList(Func<TEntity, bool> condition)
        {

            IEnumerable<TEntity> results = _dbSet.Where(condition);

            if (results == null || results.Count() < 1)
                return null;

            return results.ToList();

        }
}
}
