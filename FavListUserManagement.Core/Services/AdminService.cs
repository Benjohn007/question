using AutoMapper;
using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
using FavListUserManagement.Infrastructure.GenericRepository;
using FavListUserManagement.Infrastructure.UnitOfWork;
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
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _adminRepository = adminRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<string>> AddUserRole(string userId, UserRole role)
        {
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
                Message = $"Username:{result.UserName}, FullName:{result.FirstName} {result.LastName}, Email:{result.Email}"
            };

        }
        //public async Task<Response<User>> GetAll()
        //{
        //    var user = await _adminRepository.GetAllUser();
        //    return user.ToString();
        //    //if(user)
        //    //{
        //    //    return new Response<User>
        //    //    {

        //    //        Message = user
        //    //    };
        //    //}
        //    //return new Response<User> { Succeeded = false, };

        //}
        public async Task<Response<User>> UpdateUser(string userId, User? updateDto)
        {
            var response = new Response<User>();

            if (updateDto == null || userId != updateDto.Id)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                Response<UpdateUserDto>.Fail("unsuccessful", 400);

            }
           // User model = _mapper.Map<User>(updateDto);

            var user = await _adminRepository.UpdateUser(updateDto!);
            if(user != null)
            {
                return new Response<User>
                {
                    Succeeded = true,
                    StatusCode = (int)HttpStatusCode.OK,
                    Message = user.ToString()
                };

            }
            return new Response<User> { Succeeded = false, };

        }

    }
}

