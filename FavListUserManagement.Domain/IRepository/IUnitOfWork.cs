using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserManagementRepository userManagementRepository { get; }

        void SaveChanges();

        void BeginTransaction();

        void Rollback();
        Task SaveChangesAsync();
        
    }
}
