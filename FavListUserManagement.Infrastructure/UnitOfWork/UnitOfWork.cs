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

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _applicationDb;
        private bool _disposed;
        private IUserManagementRepository? _userManagementRepository;
        private IQuestionRepository? _questionRepository;
        private ICategoryRepository? _catergoryRepository;
        private IAnswerRepository? _answerRepository;
        private ISponsorRepository? _sponsorRepository;

        public UnitOfWork(ApplicationDbContext applicationDb)
        {
            _applicationDb = applicationDb;

        }
       
        public IUserManagementRepository userManagementRepository =>
            _userManagementRepository ??= new UserManagementRepository(_applicationDb);

        public IQuestionRepository questionRepository =>
            _questionRepository ??= new QuestionRepository(_applicationDb);
        public ICategoryRepository catergoryRepository =>
            _catergoryRepository ??= new CategoryRepository(_applicationDb);
        public IAnswerRepository answerRepository => 
            _answerRepository ??= new AnswerRepository(_applicationDb);
        public ISponsorRepository sponsorRepository =>
            _sponsorRepository ??= new SponsorRepository(_applicationDb);


        public void BeginTransaction()
        {
            _disposed = false;
        }


        public async Task SaveChanges()
        {
           await _applicationDb.SaveChangesAsync();
        }

        public void Rollback()
        {
            _applicationDb.Database.RollbackTransaction();
        }


        /*protected virtual void Dispose(bool disposing)
        {

            if (!_disposed)
            {
                if (disposing)
                {
                    _applicationDb.Dispose();
                }
            }

            _disposed = true;
        }*/

        public void Dispose()
        {
            _applicationDb.Dispose();
            GC.SuppressFinalize(this);
        }

        //public Task SaveChangesAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }

}
