using Application.Dtos;
using Application.Dtos.AccountDtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISAccount
    {
        IEnumerable<AccountInfo> GetAccounts();
        AccountInfo GetAccountById(int id);
        void UpdateAccount(AccountUpdate location);
        void RemoveAccount(int id);
        int PostUser(AccountRegister dto);
        string GenerateJwt(AccountLogin dto);
    }
}
