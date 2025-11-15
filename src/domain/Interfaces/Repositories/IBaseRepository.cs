using System.Linq.Expressions;

namespace domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        public Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter);
        public Task DeleteAsync(int id);
        public Task InsertAsync(T entity);
        public Task UpdateAsync(int id, T entity);
    }
}