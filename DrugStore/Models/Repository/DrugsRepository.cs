using DrugStore.Models.Database;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository.Base;
using System.Linq;

namespace DrugStore.Models.Repository
{
    public class DrugsRepository : BaseRepository<Drug, int>
    {
        public DrugsRepository(DrugContext context) : base(context)
        {
        }
      
        public override void Create(Drug item)
        {
            context.Drugs.Add(item);
        }
        public override Drug Get(int id)
        {
            return table.FirstOrDefault(p => p.Id == id);
        }
        public IQueryable<Drug> Drugs
        {
            get { return context.Drugs; }
        }

        public override void Update(Drug item)
        {
            var drug = Get(item.Id);
            drug.Name = item.Name;
            drug.Price = item.Price;
            drug.Manufacturer = item.Manufacturer;
            drug.Batch = item.Batch;
            drug.ShelfLife = item.ShelfLife;
            drug.InStock = item.InStock;
           
        }


    }
}