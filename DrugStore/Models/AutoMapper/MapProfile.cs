using AutoMapper;
using DrugStore.Models.DTO;
using DrugStore.Models.Entities;

namespace DrugStore.Models.AutoMapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Drug, DrugDTO>();
            CreateMap<DrugDTO, Drug>();

            CreateMap<Client, ClientDTO>();
            CreateMap<ClientDTO, Client>();

            CreateMap<Cart, CartDTO>();
            CreateMap<CartDTO, Cart>();
        }

    }
}