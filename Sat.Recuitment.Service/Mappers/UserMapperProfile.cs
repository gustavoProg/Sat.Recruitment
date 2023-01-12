using AutoMapper;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Recruitment.Core.DTOs;

namespace Sat.Recruitment.Service.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserCreateRequestDTO, User>();

            CreateMap<User, UserCreateResponseDTO>();

        }
    }
}
