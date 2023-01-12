using AutoMapper;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Recruitment.Core.DTOs;
using System.Globalization;

namespace Sat.Recruitment.Service.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserCreateRequestDTO, User>()
                .ForMember(dest => dest.Money,
                           opt => opt.MapFrom(src => decimal.Parse(src.Money, CultureInfo.InvariantCulture))
                            );

            CreateMap<User, UserCreateResponseDTO>();

        }
    }
}
