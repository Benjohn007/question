using AutoMapper;
using FavListUserManagement.Domain.DTO;
using FavListUserManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavListUserManagement.Application
{
    public class MapInitializer : Profile
    {
        public Mapper regMapper { get; }

        public MapInitializer()
        {
            var regConfig = new MapperConfiguration(conf => conf.CreateMap<RegisterDto, User>());
            regMapper = new Mapper(regConfig);
        }

    }
}
