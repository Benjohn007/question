using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.GenericRepository;
using FavListUserManagement.Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application.Services
{
    public class AdminService : IAdminService

    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminService> _logger;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IUnitOfWork unitOfWork,ILogger<AdminService> logger, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<string>> AddUserRole(string userId, UserRole role)
        {
            try
            {
                _logger.LogInformation(userId, "Add user role", role);
                var response = new Response<string>
                {
                    Succeeded = false,
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "User not found"
                };
                var result = await _adminRepository.AddUserRole(userId, role);
                if (!result) return response;

                response.Succeeded = true;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Role added successfully";
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "failed to add role");
                throw;
            }
        
        }

        public async Task<Response<string>> CreateRole(RoleDto role)
        {
            var result = await _adminRepository.CreateRole(role);
            var response = new Response<string>();
            if (result)
            {
                response.Succeeded = true;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Role created successfully";
            }
            else
            {
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = "Role cannot be created, please try again or change role";

            }

            return response;
        }

        public async Task<Response<string>> RemoveUserRole(string userId, UserRole role)
        {
            var response = new Response<string>
            {
                Succeeded = false,
                StatusCode = (int)HttpStatusCode.NotFound,
                Message = "User not found"
            };
            var result = await _adminRepository.RemoveUserRole(userId, role);
            if (!result) return response;
            response.Succeeded = true;
            response.StatusCode = (int)HttpStatusCode.OK;
            response.Message = "Role removed successfully";
            return response;
        }

        public async Task<Response<User>> RemoveUser(string userId)
        {
            try
            {
                var result = await _adminRepository.RemoveUserById(userId);
                if (!result)
                {
                    return new Response<User>
                    {
                        Succeeded = false,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "User not found"
                    };
                }
                return new Response<User>
                {
                    Succeeded = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = "Successful"
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public async Task<Response<User>> GetUserById(string userId)
        {
            var result = await _unitOfWork.userManagementRepository.GetByIdAsync(x => x.Id == userId);
            if (result == null)
            {
                return new Response<User> 
                { 
                    Succeeded = false,
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "user not found"
                };
            }
            return new Response<User>
            {
                Succeeded = true,
                StatusCode = (int)HttpStatusCode.OK,
                Message = result.ToString()
            };

        }

        public async Task<Response<UserDto>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.userManagementRepository.GetAllAsync();
                //var map = _mapper.Map<List<UserDto>>(result);
                if (result == null)
                {
                    return new Response<UserDto>
                    {
                        Succeeded = false,
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "user not found"
                    };
                }
                return new Response<UserDto>
                {
                    
                    Data = (UserDto)result,
                    Succeeded = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = result.ToString()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

