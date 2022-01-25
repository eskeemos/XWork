using Application.Dtos;
using Application.Dtos.AccountDtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISAccount
    {
        IEnumerable<AccountInfo> GetAccounts();
        AccountInfo GetAccountById(int id);
        AccountInfo AddAccount(AccountCreate location);
        void UpdateAccount(AccountUpdate location);
        void RemoveAccount(int id);
    }
}
