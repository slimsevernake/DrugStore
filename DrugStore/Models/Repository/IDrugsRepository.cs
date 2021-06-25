using DrugStore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugStore.Models.Repository
{
    public interface IDrugsRepository
    {
        IQueryable<Drug> IDrugs { get; }
    }
}
