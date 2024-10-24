using AutoMapper;
using MyApp.Application.DTOs.User;
using MyApp.Domain.Entities;

namespace MyApp.Application.Mappings {
    public class MappingProfile: Profile{
        public MappingProfile(){
            CreateMap<User, UserResponseDto>();
            CreateMap<LoginDTO, User>();
        }
    }
}