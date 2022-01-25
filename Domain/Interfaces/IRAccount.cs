using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRAccount
    {
        //IEnumerable<Account> Get();
        //Account GetById(int id);
        Account Add(Account client);
        //void Update(Account client);
        //void Remove(int id);
    }
}
