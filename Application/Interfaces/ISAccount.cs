using Application.Dtos;
using Application.Dtos.AccountDtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISAccount
    {
        //IEnumerable<AccountDto> Get();
        //UpdateAccountDto GetClientById(int id);
        AccountInfo AddAccount(AccountCreate location);
        //void UpdateClient(UpdateAccountDto location);
        //void RemoveClient(int id);
    }
}
