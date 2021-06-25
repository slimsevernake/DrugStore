using DrugStore.Models.DTO;
using System.Collections.Generic;

namespace DrugStore.Services.Interfaces
{
    public interface ICartsService
    {
        IEnumerable<CartDTO> GetAllPurchases();
        CartDTO Get(int id);
        void CreateCart(CartDTO cartDTO);
        void UpdateCart(CartDTO cartDTO);
        void Delete(int id);
    }
}
