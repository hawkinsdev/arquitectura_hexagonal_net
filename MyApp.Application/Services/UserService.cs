using AutoMapper;
using MyApp.Application.DTOs.User;
using MyApp.Application.Interfaces;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Application.Services {
    public class UserService(UserRepository userRepository, IMapper mapper) : IUserService{
        private readonly UserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<IEnumerable<UserResponseDto>> GetAllUsersAsync(){
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }
        public async Task<UserResponseDto> GetUserByIdAsync(int id){
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task CreateUserAsync(CreateUserDto userCreateDto){
            var user = _mapper.Map<Domain.Entities.User>(userCreateDto);
            await _userRepository.AddAsync(user);
        }

        public async Task DeleteUserAsync(int id){
            await _userRepository.DeleteAsync(id);
        }
    }
}