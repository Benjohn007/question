using FavListUserManagement.Domain.Entities;
using System.Linq.Expressions;

namespace FavListUserManagement.Infrastructure.GenericRepository
{   
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<bool> UpdateAsync(T Value, T entity);
        Task<bool> DeleteAsync(T Value);
    }
    
}