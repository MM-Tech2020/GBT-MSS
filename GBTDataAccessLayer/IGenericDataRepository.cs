using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GBTDataModel
{
    public interface IGenericDataRepository<T> where T : class
    {
        IList<T> GetAll(List<Expression<Func<T, object>>> navigationProperties);
        IList<T> GetList(Func<T, bool> where, List<Expression<Func<T, object>>> navigationProperties);

        IList<T> GetLists(List<Expression<Func<T, bool>>> wheres);

       
        T GetByID(long ID);
        IList<T> Add(List<T> items);
        IList<T> Update(List<T> items);

        IList<T> Remove(List<T> items);


        List<Expression<Func<T, object>>> GetNavigationProperties();

        List<Expression<Func<T, bool>>> GetWheres();

        

        IList<T> GetAllLists(List<Expression<Func<T, bool>>> wheres, List<Expression<Func<T, object>>> navigationProperties);

    }
}
