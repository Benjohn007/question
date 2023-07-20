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
            .ForMember(desc => desc.Answer, opt => opt.Ignore());

            CreateMap<Question, Category>()
                 .ForMember(desc => desc.Question, opt => opt.Ignore());

            CreateMap<CategoryDto, Category>()
                .ForMember(des => des.Question, opt => opt.Ignore());

            CreateMap<SponsorDto, Sponsor>();
            CreateMap<Sponsor, SponsorDto>();

            CreateMap<Question, QuestionResponseDto>()
                .ForMember(des => des.Text,opt => opt.UseDestinationValue());

            CreateMap<UpdateQuestionDto, Question>()
                .ForMember(des => des.Answer, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>();

            /*CreateMap<UpdateCategoryDto, Category>()
                .ForMember(des => des.Question, opt => opt.Ignore());*/
            CreateMap<Question, QuestionSearchDto>();

            CreateMap<User, UserDto>();



        }

    }

}
