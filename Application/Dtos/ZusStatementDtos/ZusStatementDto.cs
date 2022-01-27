using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.ZusStatementDtos
{
    public class ZusStatementDto : IMap
    {
        public bool IsStudent { get; set; }
        public bool IsEmployed { get; set; }
        public bool IsRetired { get; set; }
        public bool IsPensioner { get; set; }
        public bool HasCompany { get; set; }
        public bool IsInsured { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ZusStatement, ZusStatementDto>();
        }
    }
}
