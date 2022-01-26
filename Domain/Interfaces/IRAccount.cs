using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRAccount
    {
        IEnumerable<Account> Get();
        Account GetById(int id);
        void Update(Account client);
        void Remove(int id);
        int Post(Account user);
        string GetJwt(Account user);
    }
}
