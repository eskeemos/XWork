using Domain.Entities;
using Domain.Entities.Helpers;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRAccount
    {
        IEnumerable<Account> Get();
        Account GetById(int id);
        void Update(Account account);
        void Remove(int id);
        int Post(Account account);
        LogData Login(Account account);
    }
}
