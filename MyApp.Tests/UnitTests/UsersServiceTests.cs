using Moq;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Repositories;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using MyApp.Infrastructure.Data;

namespace MyApp.Tests.UnitTests {

    public class UserServiceTests{
        private readonly Mock<UserRepository> _userRepositoryMock;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            var mockContext = new Mock<MyAppDbContext>();
            _userRepositoryMock = new Mock<UserRepository>(mockContext);
            _userService = new UserService(_userRepositoryMock.Object, null!);
        }
        
        [Fact]
        public async Task GetAllUsers_ReturnsAllUsers(){
            var users = new List<User> { new() { First_name= "Jesus", Last_name="Varela", Email="jesusvarelamiranda@gmail.com", Identification_number = "123456789", Password = "MiSuperContraseña" } };
            _userRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(users);

            var result = await _userService.GetAllUsersAsync();
            Assert.Single(result);
        }
    }
}