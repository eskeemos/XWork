using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IRClient
    {
        IEnumerable<Client> Get();
        Client GetById(int id);
        Client Add(Client client);
        void Update(Client client);
        void Remove(int id);
    }
}
