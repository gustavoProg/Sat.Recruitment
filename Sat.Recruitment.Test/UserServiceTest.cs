using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Sat.Recruitment.Core.Exceptions;
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
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        private UserCreateRequestDTO _newUser;

        public UserServiceTest()
        {
            var loggerMock = new Mock<ILogger<UserService>>();

            var userMapperProfile = new UserMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(userMapperProfile));
            var mapper = new Mapper(configuration);

            var users = new UsersDA();

            var gifs = new GifsDA();

            _userService = new UserService(loggerMock.Object, mapper, users, gifs);

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


        [Theory]
        [InlineData("Normal", "10", 10)]
        [InlineData("Normal", "11", (11 * 1.8))]
        [InlineData("Normal", "99", (99 * 1.8))]
        [InlineData("Normal", "100", 100)]
        [InlineData("Normal", "101", (101 * 1.12))]
        [InlineData("Normal", "99999", (99999 * 1.12))]
        [InlineData("SuperUser", "1", 1)]
        [InlineData("SuperUser", "100", 100)]
        [InlineData("SuperUser", "101", (101 * 1.2))]
        [InlineData("Premium", "1", 1)]
        [InlineData("Premium", "100", 100)]
        [InlineData("Premium", "101", (101 * 3))]
        public async Task CreateUser_CalculateGif_Ok(string userType, string money, decimal expectedMoney)
        {
            _newUser.UserType = userType;
            _newUser.Money = money;

            // act
            var result = await _userService.CreateUserAsync(_newUser);

            // assert
            Assert.IsType<UserCreateResponseDTO>(result);
            Assert.Equal(expectedMoney, result.Money);
        }

        [Theory]
        [InlineData("Mike", "mike1@gmail.com", "+349 0022354215")]
        [InlineData("Mike1", "mike@gmail.com", "+349 0022354215")]
        [InlineData("Mike2", "mike2@gmail.com", "+349 1122354215")]
        [InlineData("Mike", "mike@gmail.com", "+349 1122354215")]
        public async Task CreateUser_Fail_Duplicated(string name, string email, string phone)
        {
            await _userService.CreateUserAsync(_newUser);

            _newUser.Name = name;
            _newUser.Email = email;
            _newUser.Phone = phone;

            // act & assert
            await Assert.ThrowsAnyAsync<CustomApplicationException>(() => _userService.CreateUserAsync(_newUser));
        }
    }
}
