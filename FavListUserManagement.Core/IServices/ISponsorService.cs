using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface ISponsorService
    {
        Task<Response<string>> Create(SponsorDto sponsor);
        Task<Response<List<SponsorDto>>> GetAll();
        Task<Response<string>> GetById(string categoryId);
        Task<Response<string>> DeleteCategory(string categoryId);
        Task<Response<string>> UpdateCategory(string sponsorId, SponsorDto sponsorDto);
    }
}
