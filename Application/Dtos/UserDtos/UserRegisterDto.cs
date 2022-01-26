using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Dtos.UserDtos
{
    public class UserRegisterDto : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public int RoleId { get; set; } = 1;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserRegisterDto, User>();
        }
    }   
}
