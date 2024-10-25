using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using MyApp.Api;
using System.Net.Http.Json;
using MyApp.Application.DTOs;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MyApp.Application.DTOs.User;

namespace MyApp.Tests.IntegrationTests{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>{
        private readonly HttpClient _client;

        public UserControllerTests(WebApplicationFactory<Program> factory) {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetAllUsers_ReturnsSuccessStatusCode()
        {
            // Act
            var response = await _client.GetAsync("/api/users");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task CreateUser_ReturnsCreatedStatusCode()
        {
            // Arrange
            var newUser = new CreateUserDto
            {
                First_name = "Test",
                Last_name = "User",
                Email = "testuser@example.com"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/users", newUser);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    }
}