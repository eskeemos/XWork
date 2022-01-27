using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System;

namespace Application.Dtos.AccountDtos
{
    public class AccountInfo : IMap
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDate { get; set; }
        public int PersonalDataId { get; set; }
        public int LocationId { get; set; }
        public int ZusStatementId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountInfo>();
        }
    }
}
