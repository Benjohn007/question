using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.DbContext;
using FavListUserManagement.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Infrastructure.Repository
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        private readonly ApplicationDbContext _applicationDb;

        public AnswerRepository(ApplicationDbContext applicationDb) : base(applicationDb)
        {
            _applicationDb = applicationDb;
        }
    }
}
