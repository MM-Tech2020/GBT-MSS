using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace SSO.DataAccessLayer
{
public interface IGenericDataRepository<T> where T : class
{
        
        IList<T> GetAll(List<Expression<Func<T, object>>> navigationProperties);
        IList<T> GetList(Func<T, bool> where, List<Expression<Func<T, object>>> navigationProperties);

        IList<T> GetLists(List<Expression<Func<T, bool>>> wheres);

        //T GetByID(int ID);
        IList<T> Add(List<T> items);
        void Add(T item);
		IList<T> Update(List<T> items);
		void Update(T item);
        IList<T> Remove(IList<T> items);


        List<Expression<Func<T, object>>> GetNavigationProperties();
		IList<T> GetAll();
		T GetById(object id);
		T FindOne(Func<T, bool> condition);
		IList<T> FindList(Func<T, bool> condition);
}
}
