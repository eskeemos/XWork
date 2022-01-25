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

        public AccountInfo AddAccount(AccountCreate account)
        {
            var data = repo.Add(mapper.Map<Account>(account));
            return mapper.Map<AccountInfo>(data);
        }

        //public IEnumerable<AccountDto> Get()
        //{
        //    return mapper.Map<IEnumerable<AccountDto>>(repo.Get());
        //}

        //public UpdateAccountDto GetClientById(int id)
        //{
        //    return mapper.Map<UpdateAccountDto>(repo.GetById(id));
        //}

        //public void RemoveClient(int id)
        //{
        //    repo.Remove(id);
        //}   

        //public void UpdateClient(UpdateAccountDto client)
        //{
        //    repo.Update(mapper.Map<Account>(client));
    //}
    }
}
