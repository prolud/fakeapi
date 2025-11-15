
using System.Linq.Expressions;
using domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace infra.Repositories
{
    public class BaseRepository<T>(AppDbContext _mySqlDbContext) : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet = _mySqlDbContext.Set<T>();

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}