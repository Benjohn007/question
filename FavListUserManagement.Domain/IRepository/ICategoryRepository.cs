using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Domain.IRepository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
