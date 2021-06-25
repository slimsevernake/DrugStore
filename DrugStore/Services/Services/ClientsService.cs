using DrugStore.Models.AutoMapper;
using DrugStore.Models.DTO;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository;
using DrugStore.Services.Interfaces;
using System.Collections.Generic;

namespace DrugStore.Services.Services
{
    public class ClientsService : IClientsService
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        AutoMap mapper = AutoMap.Instance;



        public IEnumerable<ClientDTO> GetAllClients()
        {
            var clients = unitOfWork.ClientsRepository.GetAll();
            return mapper.Mapper.Map<IEnumerable<ClientDTO>>(clients);
        }

        public ClientDTO Get(int id)
        {
            var client = unitOfWork.ClientsRepository.Get(id);
            return mapper.Mapper.Map<ClientDTO>(client);
        }

        public void CreateClient(ClientDTO clientDTO)
        {
            var client = mapper.Mapper.Map<Client>(clientDTO);
            unitOfWork.ClientsRepository.Create(client);
            unitOfWork.Save();
        }

        public void UpdateClient(ClientDTO clientDTO)
        {
            var client = mapper.Mapper.Map<Client>(clientDTO);
            unitOfWork.ClientsRepository.Update(client);
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            var client = unitOfWork.ClientsRepository.Get(id);
            unitOfWork.ClientsRepository.Delete(client.Id);
            unitOfWork.Save();
        }
    }
}