using Application.Mapper;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos
{
    public class UpdateClientDto : IMap
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual PersonalData PersonalDataId { get; set; }
        public virtual Location LocationId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Client, UpdateClientDto>();
        }
    }
}
