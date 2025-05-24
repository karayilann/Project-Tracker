
using System.Linq.Expressions;
using ProjectTracker.Core.Entities;

namespace ProjectTracker.Core.Interfaces.Services
{
    public interface IService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
