using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.IServices
{
    public interface ICatergoryService
    {
        Task<Response<string>> Create(CategoryDto catergory);
        Task<Response<List<CategoryDto>>> GetAll();
        Task<Response<string>> DeleteCategory(string categoryId);
        Task<Response<string>> UpdateCategory(string categoryId, UpdateCategoryDto categoryDto);
        Task<Response<string>> GetById(string categoryId);
    }
}
