using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.AccountDtos
{
    public class AccountCreate : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountCreate, Account>()
                .ForMember(x => x.Location, x => x.MapFrom(x => new Location()))
                .ForMember(x => x.PersonalData, x => x.MapFrom(x => new PersonalData()));
        }
    }
}
