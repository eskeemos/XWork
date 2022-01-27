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
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountRegister, Account>()
                .ForMember(x => x.PersonalData, x => x.MapFrom(x => new PersonalData()))
                .ForMember(x => x.ZusStatement, x => x.MapFrom(x => new ZusStatement()))
                .ForMember(x => x.PersonalData, x => x.MapFrom(x => new PersonalData()));
        }
    }
}
