using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using MyApp.Application.Interfaces;
using MyApp.Application.DTOs.User;

namespace MyApp.Api.Controllers { 

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase {
        private readonly IUserService _userService = userService;

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserResponseDto>> GetAll() {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}