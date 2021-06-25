using DrugStore.Models.AutoMapper;
using DrugStore.Models.DTO;
using DrugStore.Models.Entities;
using DrugStore.Models.Repository;
using DrugStore.Services.Interfaces;
using System.Collections.Generic;

namespace DrugStore.Services.Services
{
    public class CartsService : ICartsService
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        AutoMap mapper = AutoMap.Instance;



        public IEnumerable<CartDTO> GetAllPurchases()
        {
            var carts = unitOfWork.CartsRepository.GetAll();
            return mapper.Mapper.Map<IEnumerable<CartDTO>>(carts);
        }

        public CartDTO Get(int id)
        {
            var cart = unitOfWork.CartsRepository.Get(id);
            return mapper.Mapper.Map<CartDTO>(cart);
        }

        public void CreateCart(CartDTO cartDTO)
        {
            var cart = mapper.Mapper.Map<Cart>(cartDTO);
            unitOfWork.CartsRepository.Create(cart);
            unitOfWork.Save();
        }

        public void UpdateCart(CartDTO cartDTO)
        {
            var cart = mapper.Mapper.Map<Cart>(cartDTO);
            unitOfWork.CartsRepository.Update(cart);
            unitOfWork.Save();
        }
        public void Delete(int id)
        {
            var cart = unitOfWork.CartsRepository.Get(id);
            unitOfWork.CartsRepository.Delete(cart.Id);
            unitOfWork.Save();
        }
    }
}