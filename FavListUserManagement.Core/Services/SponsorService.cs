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
    }
}
