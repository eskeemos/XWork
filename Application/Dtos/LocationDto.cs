using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class LocationDto : IMap
    {
        public string Voivodeship { get; set; }
        public string County { get; set; }
        public string Municipality { get; set; }
        public string PostalCode { get; set; } 
        public string Locality { get; set; }
        public string Street { get; set; }
        public string HomeCode { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Location, LocationDto>();
            profile.CreateMap<LocationDto, Location>();
            profile.CreateMap<LocationDto, UpdateLocationDto>();
        }
    }
}
