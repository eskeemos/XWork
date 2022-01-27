using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class PersonalDataServ : ISPersonalData
    {
        private readonly IRPersonalData repo;
        private readonly IMapper mapper;

        public PersonalDataServ(IRPersonalData repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public PersonalDataDto GetPDById(int id)
        {
            return mapper.Map<PersonalDataDto>(repo.GetById(id));
        } 

        public void UpdatePD(UpdatePersonalDataDto personalData)
        {
            repo.Update(mapper.Map<PersonalData>(personalData));
        }
    }
}
