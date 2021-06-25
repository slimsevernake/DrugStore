using DrugStore.Models.AutoMapper;
using DrugStore.Models.DTO;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository;
using DrugStore.Services.Interfaces;
using System.Collections.Generic;

namespace DrugStore.Services.Services
{
    public class DrugsService : IDrugsService
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        AutoMap mapper = AutoMap.Instance;



        public IEnumerable<DrugDTO> GetAllDrugs()
        {
            var drugs = unitOfWork.DrugsRepository.GetAll();
            return mapper.Mapper.Map<IEnumerable<DrugDTO>>(drugs);
        }

        public DrugDTO Get(int id)
        {
            var drug = unitOfWork.DrugsRepository.Get(id);
            return mapper.Mapper.Map<DrugDTO>(drug);
        }

        public void CreateDrug(DrugDTO drugDTO)
        {
            var drug = mapper.Mapper.Map<Drug>(drugDTO);
            unitOfWork.DrugsRepository.Create(drug);
            unitOfWork.Save();
        }

        public void UpdateDrug(DrugDTO drugDTO)
        {
            var drug = mapper.Mapper.Map<Drug>(drugDTO);
            unitOfWork.DrugsRepository.Update(drug);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            var drug = unitOfWork.DrugsRepository.Get(id);
            unitOfWork.DrugsRepository.Delete(drug.Id);
            unitOfWork.Save();
        }
    }
}