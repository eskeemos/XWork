using Application.Dtos.ZusStatementDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ZusStatementServ : ISZusStatement
    {
        private readonly IRZusStatement repo;
        private readonly IMapper mapper;

        public ZusStatementServ(IRZusStatement repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public ZusStatementDto GetZusStatementById(int id)
        {
            return mapper.Map<ZusStatementDto>(repo.GetById(id));
        }
        public void UpdateZusStatement(UpdateZusStatementDto dto)
        {
            repo.Update(mapper.Map<ZusStatement>(dto));
        }
    }
}
