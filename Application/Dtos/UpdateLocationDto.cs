using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class UpdateLocationDto : IMap
    {
        public int Id { get; set; }
        public string Voivodeship { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string PostalCode { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string HomeCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateLocationDto, Location>();
            profile.CreateMap<Location, UpdateLocationDto>();
        }
    }
}
