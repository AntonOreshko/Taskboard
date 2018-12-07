using AutoMapper;
using DomainModels.Models;
using WebApi.Dto;

namespace WebApi.Configurators
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>();

            CreateMap<User, UserReturnDto>();
        }
    }
}
