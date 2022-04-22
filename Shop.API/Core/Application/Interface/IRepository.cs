using System.Linq.Expressions;

namespace Shop.API.Core.Interface
{
    public interface IRepository <T> where T : class,new()
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetById (object id);
        Task<T?> GetByFilter(Expression<Func<T, bool>> filter);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
    }
}
