using DrugStore.Models.Database;
using System;

namespace DrugStore.Models.Repository
{
    public class UnitOfWork : IDisposable
    {

        private static UnitOfWork instance;

        private DrugContext context = new DrugContext();
        private DrugsRepository drugsRepository;
        private CartsRepository cartsRepository;
        private ClientsRepository clientsRepository;

        public static UnitOfWork Instance => instance ?? (instance = new UnitOfWork());

        public DrugsRepository DrugsRepository
            => drugsRepository ?? (drugsRepository = new DrugsRepository(context));

        public CartsRepository CartsRepository
            => cartsRepository ?? (cartsRepository = new CartsRepository(context));
        public ClientsRepository ClientsRepository
            => clientsRepository ?? (clientsRepository = new ClientsRepository(context));


        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save() => context.SaveChanges();
    }
}