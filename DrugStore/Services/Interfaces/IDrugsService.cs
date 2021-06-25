using DrugStore.Models.DTO;
using System.Collections.Generic;

namespace DrugStore.Services.Interfaces
{
    public interface IDrugsService
    {
        IEnumerable<DrugDTO> GetAllDrugs();
        DrugDTO Get(int id);
        void CreateDrug(DrugDTO drugDTO);
        void UpdateDrug(DrugDTO drugDTO);
        void Delete(int id);

    }
}
