using Application.Dtos;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ISClient
    {
        IEnumerable<ClientDto> Get();
        UpdateClientDto GetClientById(int id);
        UpdateClientDto AddClient(ClientDto location);
        void UpdateClient(UpdateClientDto location);
        void RemoveClient(int id);
    }
}
