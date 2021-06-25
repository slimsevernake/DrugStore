using DrugStore.Models.Database;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository.Base;
using System.Linq;

namespace DrugStore.Models.Repository
{
    public class ClientsRepository : BaseRepository<Client, int>
    {
        public ClientsRepository(DrugContext context) : base(context)
        {
        }

        public override void Create(Client item)
        {
            context.Clients.Add(item);
        }
        public override Client Get(int id)
        {
            return table.FirstOrDefault(p => p.Id == id);
        }

        public override void Update(Client item)
        {
            var client = Get(item.Id);
            client.FirstName = item.FirstName;
            client.MiddleName = item.MiddleName;
            client.LastName = item.LastName;
            client.Age = item.Age;
            client.Email = item.Email;
            client.Phone = item.Phone;
        }


    }
}