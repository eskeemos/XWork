using Application.Dtos.AccountDtos;
using Domain.Entities.Helpers;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISAccount
    {
        IEnumerable<AccountInfo> GetAccounts();
        AccountInfo GetAccountById(int id);
        void UpdateAccount(AccountUpdate dto);  
        void RemoveAccount(int id);
        int PostUser(AccountRegister dto);
        LogData LogToAccount(AccountLogin dto);
    }
}
