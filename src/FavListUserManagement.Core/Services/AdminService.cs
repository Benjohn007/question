﻿using FavListUserManagement.Application.IServices;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using FavListUserManagement.Domain.IRepository;
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

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
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
    }
}
