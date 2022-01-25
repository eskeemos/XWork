using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.AccountDtos
{
    public class AccountInfo : IMap
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual PersonalData PersonalData { get; set; }
        public virtual Location Location { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Account, AccountInfo>();
        }
    }
}
