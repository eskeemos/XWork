using Application.Dtos.UserDtos;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserServ : ISUser
    {
        private readonly IRUser repo;
        private readonly IMapper mapper;
        public UserServ(IRUser repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public string GenerateJwt(UserLoginDto dto)
        {
            return repo.GetJwt(mapper.Map<User>(dto));
        }

        public int PostUser(UserRegisterDto dto)
        {
            var id = repo.Post(mapper.Map<User>(dto));
            return id;
        }
    }
}
