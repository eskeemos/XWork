using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Dtos.AccountDtos
{
    public class AccountRegister : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public int RoleId { get; set; } = 1;
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountRegister, Account>()
                .ForMember(x => x.Location, x => x.MapFrom(x => new Location()))
                .ForMember(x => x.PersonalData, x => x.MapFrom(x => new PersonalData()));
        }
    }
}
