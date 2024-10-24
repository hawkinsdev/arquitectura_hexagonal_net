using MyApp.Application.DTOs.User;

namespace MyApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllUsersAsync();
        Task<UserResponseDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto userCreateDto);
        Task DeleteUserAsync(int id);
    }
}
