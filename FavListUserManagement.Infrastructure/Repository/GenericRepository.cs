using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;
using System.Linq.Expressions;
using System.Linq;

namespace FavListUserManagement.Infrastructure.GenericRepository
{
    //public class GenericRepository<TEntity> : IGenericRepository1<TEntity> where TEntity : BaseEntity
    //{
    //    private readonly ApplicationDbContext _applicationDb;
    //    private DbSet<TEntity> DbSet;
    //    // protected DbSet<TEntity> _dbSet;
    //    // public IQueryable<TEntity> Table => _dbSet; 
    //    //public IQueryable<TEntity> TableNoTracking => _dbSet.AsNoTracking();

    //    public GenericRepository(ApplicationDbContext applicationDb)
    //    {
    //        _applicationDb = applicationDb;
    //        this.DbSet = _applicationDb.Set<TEntity>();
    //    }

    //    public TEntity Add(TEntity entity)
    //    {
    //        try
    //        {
    //            entity.Created_Date = DateTime.Now;
    //            entity.Is_Deleted = false;
    //            var result = DbSet.Add(entity);
    //            _applicationDb.SaveChanges();
    //            return result.Entity;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }

    //    }

    //    public List<TEntity> Add(List<TEntity> entity)
    //    {
    //        try
    //        {
    //            int count = 0;
    //            foreach (var rec in entity)
    //            {

    //                rec.Created_Date = DateTime.Now;
    //                rec.Is_Deleted = false;
    //                var result = DbSet.Add(rec);
    //                if (count == 500)
    //                {
    //                    _applicationDb.SaveChanges();
    //                    count = 0;
    //                }
    //                count += 1;
    //            }
    //            _applicationDb.SaveChanges();

    //            return entity;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }
    //    public TEntity Update(TEntity entity)
    //    {
    //        try
    //        {
    //            entity.Last_Modified = DateTime.Now;
    //            var result = DbSet.Update(entity);
    //            int rowAffected = _applicationDb.SaveChanges();
    //            if (rowAffected > 0)
    //            {
    //                return result.Entity;
    //            }
    //            return null;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public TEntity GetById(Guid Id)
    //    {
    //        try
    //        {
    //            var result = DbSet.First(p => p.Id == Id);
    //            if (result == null)
    //            {
    //                return null;
    //            }
    //            if (result.Is_Deleted)
    //            {
    //                return null;
    //            }
    //            return result;
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public TEntity GetOne(Func<TEntity, Boolean> where)
    //    {
    //        try
    //        {
    //            var result = DbSet.Where<TEntity>(where);
    //            if (result == null)
    //            {
    //                return null;
    //            }
    //            result = result.Where(p => p.Is_Deleted == false);

    //            if (result == null)
    //            {
    //                return null;
    //            }
    //            return result.FirstOrDefault<TEntity>();
    //        }
    //        catch (Exception)
    //        {

    //            throw;
    //        }
    //    }

    //    public List<TEntity> GetAll()
    //    {
    //        var result = DbSet.ToList();
    //        if (result == null)
    //        {
    //            return null;
    //        }
    //        result = result.Where(p => p.Is_Deleted == false).ToList();

    //        if (result == null)
    //        {
    //            return null;
    //        }
    //        return DbSet.ToList();
    //    }

    //    public List<TEntity> GetMany(Func<TEntity, Boolean> where)
    //    {
    //        var result = DbSet.Where<TEntity>(where).OrderByDescending(a => a.Id).ToList();
    //        if (result == null)
    //        {
    //            return null;
    //        }
    //        result = result.Where(p => p.Is_Deleted == false).ToList();
    //        return result;
    //    }

    //    public (List<TEntity> records, int totalRecords) Paginate(int page, int pageSize, Func<TEntity, Boolean> where)
    //    {
    //        var result = DbSet
    //                    .Skip((page) * pageSize)
    //                    .Take(pageSize)
    //                    .Where<TEntity>(where)
    //                    .ToList();

    //        int count = DbSet.Count();

    //        return (result, count);
    //    }

    //}

    //public class GenericRepository<T> : IGenericRepository<T> where T : class
    //{
    //    protected DbSet<T> _dbSet;
    //    public IQueryable<T> Table => _dbSet;
    //    public IQueryable<T> TableNoTracking => _dbSet.AsNoTracking();
    //    private readonly ApplicationDbContext _applicationDbContext;



    //    public GenericRepository(ApplicationDbContext applicationDbContext)
    //    {
    //        _applicationDbContext = applicationDbContext;
    //        _dbSet = applicationDbContext.Set<T>();
    //    }

    //    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    //    public async Task DeleteAsync<T>(T Value)
    //    {
    //        var entity = await _dbSet.FindAsync(Value);
    //        EntityEntry entityEntry = _dbSet.Remove(entity);
    //        entityEntry.State = EntityState.Deleted;
    //    }

    //    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    //    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    //    {
    //        IQueryable<T> query = _dbSet;

    //        if (filter != null)
    //        {
    //            query = query.Where(filter);
    //        }
    //        return await query.ToListAsync();

    //    }


    //    public async Task<T> GetByIdAsync(string id, T Value) => await _dbSet.FindAsync(Value);

    //    public async Task<T> GetByIdAsync(Expression<Func<T, bool>>? filter = null, bool tracked = true)
    //    {
    //        IQueryable<T> query = _dbSet;
    //        if (!tracked)
    //        {
    //            query = query.AsNoTracking();
    //        }
    //        if (filter != null)
    //        {
    //            query = query.Where(filter);
    //        }
    //        return await query.FirstOrDefaultAsync();
    //    }


    //    public async Task UpdateAsync<T>(T Value, T entity)
    //    {
    //        var entityUpdate = await _dbSet.FindAsync(Value);
    //        EntityEntry entityEntry = _dbSet.Update(entityUpdate);
    //        entityEntry.State = EntityState.Modified;
    //    }
    //}

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
