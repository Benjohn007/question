using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq.Expressions;
using System.Linq;

namespace FavListUserManagement.Infrastructure.GenericRepository
{

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;
        private readonly ApplicationDbContext _applicationDb;

        public IQueryable<T> Table => _dbSet;
        public IQueryable<T> TableNoTracking => _dbSet.AsNoTracking();



        public GenericRepository(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;
            _dbSet = _applicationDb.Set<T>();
        }



        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task<bool> DeleteAsync(T Value)
        {
            var entity = await _dbSet.FindAsync(Value);
            if(entity == null)
            {
                return false;
            }
            EntityEntry entityEntry = _dbSet.Remove(entity);
            entityEntry.State = EntityState.Deleted;
            return true;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.ToListAsync();

        }


        //public async Task<T> GetByIdAsync(string id, T value) => await _dbSet.FindAsync(value);

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>>? filter, bool tracked = true)
        {
            IQueryable<T> query = _dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query == null ? null : await query.FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateAsync(T Value, T entity)
        {
            var entityUpdate = await _dbSet.FindAsync(Value);
            if (entityUpdate == null)
            {
                return false;
            }
            EntityEntry entityEntry = _dbSet.Update(entityUpdate);
            entityEntry.State = EntityState.Modified;
            return true;
        }
    }
}
