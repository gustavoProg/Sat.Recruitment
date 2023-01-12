
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.DataAccess.Implementations;
using Sat.Recruitment.Recruitment.Core.DTOs;
using Sat.Recruitment.Service.Implementations;
using Sat.Recruitment.Service.Interfaces;
using Sat.Recruitment.Service.Mappers;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    [Collection("Non-Parallel Collection")]
    public class UserControllerTest
    {
        private readonly IUserService _userService;

        private readonly UsersController _userController;

        private UserCreateRequestDTO _newUser;

        public UserControllerTest()
        {
            var loggerMock = new Mock<ILogger<UserService>>();

            var userMapperProfile = new UserMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapperProfile));
            var mapper = new Mapper(configuration);

            var users = new UsersDA();

            var gifs = new GifsDA();

            _userService = new UserService(loggerMock.Object, mapper, users, gifs);

            _userController = new UsersController(_userService);

            _newUser = new UserCreateRequestDTO
            {
                Name = "Mike",
                Email = "mike@gmail.com",
                Address = "Av. Juan G",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = "124"
            };
        }


        [Fact]
        public async Task CreateUser_Ok()
        {
            var actionResult = await _userController.CreateAsync(_newUser);

            var statusCodeResult = (IStatusCodeActionResult)actionResult;

            Assert.Equal(Microsoft.AspNetCore.Http.StatusCodes.Status201Created, statusCodeResult.StatusCode);
        }
    }
}
