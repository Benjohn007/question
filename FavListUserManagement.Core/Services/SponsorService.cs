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
    public class SponsorService : ISponsorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISponsorRepository _sponsorRepository;
        private readonly IMapper _mapper;

        public SponsorService(IUnitOfWork unitOfWork, ISponsorRepository sponsorRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _sponsorRepository = sponsorRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Create(SponsorDto sponsor)
        {
            try
            {
                var response = new Response<string>();

                if (sponsor != null)
                {
                    var mapp = _mapper.Map<Sponsor>(sponsor);

                    await _sponsorRepository.AddAsync(mapp);

                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Successfully registered";
                    response.Data = mapp.ToString();

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

        public async Task<Response<List<SponsorDto>>> GetAll()
        {
            try
            {
                var response = new Response<List<SponsorDto>>();
                IEnumerable<Sponsor> cat = await _sponsorRepository.GetAllAsync(x => !x.Is_Deleted);


                var result = _mapper.Map<List<SponsorDto>>(cat);
                if (cat != null)
                {
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Data = result;

                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "categories can not be found";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Response<string>> GetById(string categoryId)
        {
            try
            {
                var response = new Response<string>();
                var cat = await _sponsorRepository.GetByIdAsync(x => x.Id == categoryId);
                if (cat != null && !cat.Is_Deleted)
                {
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Data = cat.Name;

                    return response;
                }
                if (cat != null && cat.Is_Deleted)
                {
                    response.Succeeded = false;
                    response.StatusCode = (int)HttpStatusCode.Found;
                    response.Message = "this category is deleted";
                    response.Data = cat.Name;

                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "category can not be found";
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Response<string>> DeleteCategory(string categoryId)
        {
            try
            {
                var response = new Response<string>();
                var cat = await _sponsorRepository.GetByIdAsync(x => x.Id == categoryId);

                if (cat != null)
                {
                    cat.Is_Deleted = true;
                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.NoContent;
                    response.Message = "Successfully deleted";
                    await _unitOfWork.SaveChanges();
                    return response;
                }
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                response.Message = "failed. user not found";
                return response;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        public async Task<Response<string>> UpdateCategory(string sponsorId, SponsorDto sponsorDto)
        {
            var response = new Response<string>();

            if (sponsorId != null)
            {
                var result = await _sponsorRepository.GetByIdAsync(x => x.Id == sponsorId);

                if (result != null)
                {
                    result.Name = string.IsNullOrEmpty(sponsorDto.Name) ? result.Name : sponsorDto.Name;
                    result.Logo_S3_Url = string.IsNullOrEmpty(sponsorDto.Logo_S3_Url) ? result.Logo_S3_Url : sponsorDto.Logo_S3_Url;
                    result.Ads_S3_Url = string.IsNullOrEmpty(sponsorDto.Ads_S3_Url) ? result.Ads_S3_Url : sponsorDto.Ads_S3_Url;

                    response.Succeeded = true;
                    response.StatusCode = (int)HttpStatusCode.Created;
                    response.Message = "Successfully Updated";
                    response.Data = $"Name:{result.Name} Ads:({result.Ads_S3_Url} Logo:{result.Logo_S3_Url}";

                    await _unitOfWork.SaveChanges();

                    return response;

                }

            }
            response.Succeeded = false;
            response.StatusCode = (int)HttpStatusCode.NotFound;
            response.Message = "Failed to update, please change check the sponsor Id.";
            return response;

        }

    }
}
