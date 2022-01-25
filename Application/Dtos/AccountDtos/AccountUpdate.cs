using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.AccountDtos
{
    public class AccountUpdate : IMap
    {
        public int Id { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountUpdate, Account>();
        }
    }
}
