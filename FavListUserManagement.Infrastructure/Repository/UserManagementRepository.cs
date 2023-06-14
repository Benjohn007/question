using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.DbContext;
using FavListUserManagement.Infrastructure.GenericRepository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using System.Data.Entity;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace FavListUserManagement.Infrastructure.Repository
{
    public class UserManagementRepository : GenericRepository<User>,  IUserManagementRepository
    {
        private readonly ApplicationDbContext _applicationDb;

        public UserManagementRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }
        
           
        //public async Task AddAsync(User entity)
        //{
        //    await _applicationDb.AddAsync(entity);
        //   await _unitOfWork.SaveChangesAsync();
        //}

        //public async Task<bool> DeleteAsync(User Id)
        //{
        //    try
        //    {
        //        var user = await _applicationDb.Users.FindAsync(Id);
        //        if (user != null)
        //            _applicationDb.Users.Remove(user);
        //        _applicationDb.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
           

        //}

        //public async Task<IEnumerable<User>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>>? filter = null)
        //{
        //    try
        //    {
        //        var user = await _applicationDb.Users.ToListAsync();
        //        return user;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception(ex.Message);
        //    }
        //}

        //public async Task<User?> GetByIdAsync(Expression<Func<User, bool>>? filter = null, bool tracked = true)
        //{
        //    try
        //    {
        //        await _applicationDb.Users.Where( x => x.Id ==(filter?.ToString())).ToListAsync();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public Task<bool> UpdateAsync(User Value, User entity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
