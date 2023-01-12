using AutoMapper;
using Microsoft.Extensions.Logging;
using Sat.Recruitment.Core.Entities;
using Sat.Recruitment.Core.Enums;
using Sat.Recruitment.Core.Exceptions;
using Sat.Recruitment.DataAccess.Interfaces;
using Sat.Recruitment.Recruitment.Core.DTOs;
using Sat.Recruitment.Service.Extensions;
using Sat.Recruitment.Service.Interfaces;
using System.Threading.Tasks;

namespace Sat.Recruitment.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _log;

        private readonly IMapper _mapper;

        private readonly IUsersDA _usersInfo;

        private readonly IGifsDA _gifsInfo;


        public UserService(ILogger<UserService> log, IMapper mapper, IUsersDA usersInfo, IGifsDA gifsInfo)
        {
            _log = log;

            _mapper = mapper;

            _usersInfo = usersInfo;

            _gifsInfo = gifsInfo;
        }


        public async Task<UserCreateResponseDTO> CreateUserAsync(UserCreateRequestDTO user)
        {
            var newUser = _mapper.Map<User>(user);

            newUser.CalculateGif(_gifsInfo.GetAll());

            newUser.NormalizeEmail();

            if (newUser.IsDuplicated(_usersInfo.GetAll()))
            {
                _log.LogDebug("The user is duplicated");

                throw new CustomApplicationException("User is duplicated", ApplicationErrors.Duplicated);
            }

            _usersInfo.Add(newUser);

            _log.LogDebug("User Created");

            var responseUser = _mapper.Map<UserCreateResponseDTO>(newUser);

            return responseUser;
        }
    }
}
