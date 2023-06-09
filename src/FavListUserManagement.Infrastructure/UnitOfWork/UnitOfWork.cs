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
   // public class UnitOfWork : IUnitOfWork
    //{
    //    private readonly ApplicationDbContext _applicationDb;

    //    public UnitOfWork(ApplicationDbContext applicationDb)
    //    {
    //        _applicationDb = applicationDb;
    //    }
    //   // private GenericRepository<User> _userRepository;
    //    private GenericRepository<SignUp> _signUpRepository;

    //    //public GenericRepository<User> UserRepository
    //    //{
    //    //    get
    //    //    {
    //    //        if(_userRepository == null) { _userRepository = new GenericRepository<User>(_applicationDb); }
    //    //        return _userRepository;
    //    //    }
    //    //}
    //    public GenericRepository<SignUp> SignUpRepository
    //    {
    //        get
    //        {
    //            if(SignUpRepository == null) { _signUpRepository = new GenericRepository<SignUp>(_applicationDb); }
    //            return _signUpRepository;
    //        }
    //    }



   // }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _applicationDb;
        private bool _disposed;
        //private IAdminRepository? _adminRepository;
        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;

        }
        //public IHotelRepository hotelRepository =>
        //    _hotelRepository ??= new HotelRepository(_applicationDb);

        //public IRoomRepository roomRepository =>
        //    _roomRepository ??= new RoomRespository(_applicationDb);
        //public IAdminRepository adminRepository =>
        //    _adminRepository ??= new AdminRepository();


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
