using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class LocationServ : ISLocation
    {
        private readonly IMapper mapper;
        private readonly IRLocation repo;

        public LocationServ(IRLocation repo, IMapper mapper)
        {
            this.mapper = mapper;
            this.repo = repo;
        }
        public UpdateLocationDto Add(LocationDto location)
        {
            var data = repo.Add(mapper.Map<Location>(location));
            return mapper.Map<UpdateLocationDto>(data);
        }

        public LocationDto GetLocationById(int id)
            => mapper.Map<LocationDto>(repo.GetById(id));

        public void Remove(int id)
        {
            repo.Remove(id);
        }

        public void Update(UpdateLocationDto location)
        {
            repo.Update(mapper.Map<Location>(location));
        }
    }
}
