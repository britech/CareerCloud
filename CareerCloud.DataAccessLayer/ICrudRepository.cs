using System.Linq.Expressions;

namespace CareerCloud.DataAccessLayer
{
    public interface ICrudRepository<T> : IRepository
    {
        void AddAll(T[] items);
        T FindOne(Expression<Func<T, bool>> expression);
        void UpdateAll(T[] items);
        void RemoveAll(T[] items);
    }
}
