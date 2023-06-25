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
    public interface IUnitOfWork
    {
        IUserManagementRepository userManagementRepository { get; }
        IQuestionRepository questionRepository { get; }
        ICategoryRepository catergoryRepository { get; }
        IAnswerRepository answerRepository { get; }
        ISponsorRepository sponsorRepository { get; }
        IQuestionDraftRepository questionDraftRepository { get; }

        Task SaveChanges();

        void BeginTransaction();

        void Rollback();
       // Task SaveChangesAsync();
        
    }
}
