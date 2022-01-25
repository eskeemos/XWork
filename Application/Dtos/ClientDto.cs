using Application.Mapper;
using AutoMapper;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Dtos
{
    public class ClientDto : IMap
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual PersonalData PersonalDataId { get; set; }
        public virtual Location LocationId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ClientDto, Client>();
            profile.CreateMap<Client, UpdateClientDto>();
            profile.CreateMap<Client, ClientDto>();
        }
    }
}
