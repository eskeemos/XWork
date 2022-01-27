using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.AccountDtos
{
    public class AccountLogin : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public void Mapping(Profile profile)
        { 
            profile.CreateMap<AccountLogin, Account>();
        }
    }
}
