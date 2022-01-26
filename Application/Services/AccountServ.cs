using Application.Dtos;
using Application.Dtos.AccountDtos;
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
    public class AccountServ : ISAccount
    {
        private readonly IRAccount repo;
        private readonly IMapper mapper;

        public AccountServ(IRAccount repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IEnumerable<AccountInfo> GetAccounts()
        {
            var data = repo.Get();
            return mapper.Map<IEnumerable<AccountInfo>>(data);
        }

        public AccountInfo GetAccountById(int id)
        {
            return mapper.Map<AccountInfo>(repo.GetById(id));
        }

        public void RemoveAccount(int id)
        {
            repo.Remove(id);
        }

        public void UpdateAccount(AccountUpdate account)
        {
            repo.Update(mapper.Map<Account>(account));
        }

        public int PostUser(AccountRegister dto)
        {
            var id = repo.Post(mapper.Map<Account>(dto));
            return id;
        }

        public string GenerateJwt(AccountLogin dto)
        {
            return repo.GetJwt(mapper.Map<Account>(dto));
        }
    }
}
