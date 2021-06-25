using DrugStore.Models.Entities;
using System.Data.Entity;

namespace DrugStore.Models.Database
{
    public class DrugContext : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Client> Clients { get; set; }

        static DrugContext()
        {
            System.Data.Entity.Database.SetInitializer(new DrugInitializer());
        }
        public DrugContext() : base("DefaultConnection")
        {

        }
    }
}