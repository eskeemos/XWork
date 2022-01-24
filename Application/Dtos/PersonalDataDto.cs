using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class PersonalDataDto : IMap
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pesel { get; set; }
        public bool SanitaryBook { get; set; }
        public string BankAccount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PersonalData, PersonalDataDto>();
            profile.CreateMap<PersonalDataDto, PersonalData>();

        }
    }
}
