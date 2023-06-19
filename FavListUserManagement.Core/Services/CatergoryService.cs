using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.Repository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.Services
{
    public class CatergoryService : ICatergoryService
    {
        private readonly ICategoryRepository _catergoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CatergoryService(ICategoryRepository catergoryRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _catergoryRepository = catergoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> Create(CatergoryDto catergory)
        {
            try
            {
                var response = new Response<string>();

                if (catergory != null)
                {
                    var mapp = _mapper.Map<Category>(catergory);

                    await _catergoryRepository.AddAsync(mapp);

                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Successfully registered";
                    response.Data = "";

                    await _unitOfWork.SaveChanges();

                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                response.Message = "Failed to register, please change check the email, username and password.";
                return response;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
