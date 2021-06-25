using DrugStore.Models.Database;
using DrugStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DrugStore.Models.Repository.Base
{
    public abstract class BaseRepository<TValue, TKey> : IRepository<TValue, TKey>
         where TValue : class
         where TKey : struct
    {
        protected DrugContext context;
        protected DbSet<TValue> table => context.Set<TValue>();
        public BaseRepository(DrugContext context)
        {
            this.context = context;
        }
        public virtual void Create(TValue item)
        {
            context.Entry(item).State = EntityState.Added;
        }

        public virtual void Delete(TKey id)
        {
            var item = Get(id);
            context.Entry(item).State = EntityState.Deleted;
        }

        public abstract TValue Get(TKey id);


        public virtual IEnumerable<TValue> GetAll()
        {
            return context.Set<TValue>().ToList();
        }

        public virtual IEnumerable<TValue> GetAll(Func<TValue, bool> predicate)
        {
            return context.Set<TValue>()
                .Where(predicate)
                .ToList();
        }

        public abstract void Update(TValue item);

    }
}