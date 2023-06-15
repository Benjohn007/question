using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.DbContext;
using FavListUserManagement.Infrastructure.GenericRepository;
using FavListUserManagement.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Infrastructure.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDb;
        private bool _disposed;
        private IUserManagementRepository? _userManagementRepository;

        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;

        }
       
        public IUserManagementRepository userManagementRepository =>
            _userManagementRepository ??= new UserManagementRepository(_applicationDb);

        public void BeginTransaction()
        {
            _disposed = false;
        }


        public async void SaveChanges()
        {
           await _applicationDb.SaveChangesAsync();
        }

        public void Rollback()
        {
            _applicationDb.Database.RollbackTransaction();
        }


        protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDb.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }

}
