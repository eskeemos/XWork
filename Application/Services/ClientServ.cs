using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientServ : ISClient
    {
        private readonly IRClient repo;
        private readonly IMapper mapper;

        public ClientServ(IRClient repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public UpdateClientDto AddClient(ClientDto client)
        {
            var data = repo.Add(mapper.Map<Client>(client));
            return mapper.Map<UpdateClientDto>(data);
        }

        public IEnumerable<ClientDto> Get()
        {
            return mapper.Map<IEnumerable<ClientDto>>(repo.Get());
        }

        public UpdateClientDto GetClientById(int id)
        {
            return mapper.Map<UpdateClientDto>(repo.GetById(id));
        }

        public void RemoveClient(int id)
        {
            repo.Remove(id);
        }   

        public void UpdateClient(UpdateClientDto client)
        {
            repo.Update(mapper.Map<Client>(client));
        }
    }
}
