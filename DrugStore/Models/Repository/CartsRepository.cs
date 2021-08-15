using DrugStore.Models.Database;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository.Base;
using System.Linq;

namespace DrugStore.Models.Repository
{
    public class CartsRepository : BaseRepository<Cart, int>
    {
        public CartsRepository(DrugContext context) : base(context)
        {
        }

        public override void Create(Cart item)
        {
            context.Carts.Add(item);
        }
        public override Cart Get(int id)
        {
            return table.FirstOrDefault(p => p.Id == id);
        }

        public override void Update(Cart item)
        {
            var purchase = Get(item.Id);
        }


    }
}