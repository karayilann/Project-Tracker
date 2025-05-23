
using System.Linq.Expressions;

namespace ProjectTracker.Core.Interfaces.Repositories
{
    public interface IGenericRepository<T>  where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> WhereAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> FindAsync(Expression<Func<T, bool>> filterExpression);
        Task<List<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includeProperties);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
