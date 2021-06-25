using System;
using System.Collections.Generic;

namespace DrugStore.Models.Interfaces
{
    public interface IRepository<TValue, TKey>
       where TValue : class
       where TKey : struct
    {
        void Create(TValue item);
        void Update(TValue item);
        TValue Get(TKey id);
        IEnumerable<TValue> GetAll();
        IEnumerable<TValue> GetAll(Func<TValue, bool> predicate);
        void Delete(TKey id);
    }
}
