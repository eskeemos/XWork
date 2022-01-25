using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastucture.Repositories
{
    public class ClientRepo : IRClient
    {
        private static ISet<Client> datas = new HashSet<Client>()
        {
            new Client()
            {
                Id = 1,
                Email = "mail",
                Password = "123"
            }
        };

        public Client Add(Client client)
        {
            datas.Add(client);
            return client;
        }

        public IEnumerable<Client> Get()
        {
            return datas;
        }

        public Client GetById(int id)
        {
            return datas.SingleOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            datas.Remove(GetById(id));
        }

        public void Update(Client client)
        {
            var x = client;
        }
    }
}
