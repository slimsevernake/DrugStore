using DrugStore.Models.DTO;
using System.Collections.Generic;

namespace DrugStore.Services.Interfaces
{
    public interface IClientsService
    {
        IEnumerable<ClientDTO> GetAllClients();
        ClientDTO Get(int id);
        void CreateClient(ClientDTO clientDTO);
        void UpdateClient(ClientDTO clientDTO);
        void Delete(int id);
    }
}
