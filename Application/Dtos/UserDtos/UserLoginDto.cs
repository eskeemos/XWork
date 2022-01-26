using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.UserDtos
{
    public class UserLoginDto : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserLoginDto, User>();
        }
    }
}
