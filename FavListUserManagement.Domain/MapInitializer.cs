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

            CreateMap<QuestionDto, Question>()
            .ForMember(desc => desc.Answer,
            opt => opt.Ignore());

            CreateMap<Question, Category>()
                 .ForMember(desc => desc.Question,
            opt => opt.Ignore());

            CreateMap<CatergoryDto, Category>()
                .ForMember(des => des.Question,
                opt => opt.Ignore());
            CreateMap<SponsorDto, Sponsor>();
            CreateMap<Question, QuestionResponseDto>()
                .ForMember(des => des.Text,
                opt => opt.UseDestinationValue());
            CreateMap<UpdateQuestionDto, Question>();


            //  .ForMember(
            //    dest => dest.UserId,
            //    opt => opt.MapFrom(src => $"{src.UserId}")
            //)
            // .ForMember(
            //    dest => dest.Text,
            //    opt => opt.MapFrom(src => $"{src.Text}")
            //)
            // .ForMember(
            //    dest => dest.Answer,
            //    opt => opt.MapFrom(src => $"{src.Answer}")
            //)
            // .ForPath(
            //    dest => dest.Catergory.CatergoryType,
            //    opt => opt.MapFrom(src => $"{src.CatergoryType}")
            //)
            // .ForMember(
            //    dest => dest.SponsorId,
            //    opt => opt.MapFrom(src => $"{src.SponsorId}"));
        }

    }

}
