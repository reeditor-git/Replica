using AutoMapper;
using Replica.Domain.Entities.Hookahs;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Hookahs.ComponentCategory;
using Replica.DTO.Hookahs.Hookah;
using Replica.DTO.Hookahs.HookahComponent;
using Replica.DTO.Orders;
using Replica.DTO.Orders.Category;
using Replica.DTO.Orders.GameZone;
using Replica.DTO.Orders.Order;

namespace Replica.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ComponentCategoryDTO, ComponentCategory>();
            CreateMap<ComponentCategory, ComponentCategoryDTO>();

            CreateMap<HookahDTO, Hookah>();
            CreateMap<Hookah, HookahDTO>();

            CreateMap<HookahComponentDTO, HookahComponent>();
            CreateMap<HookahComponent, HookahComponentDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<GameZoneDTO, GameZone>();
            CreateMap<GameZone, GameZoneDTO>();

            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<SubcategoryDTO, Subcategory>();
            CreateMap<Subcategory, SubcategoryDTO>();

            CreateMap<TableDTO, Table>();
            CreateMap<Table, TableDTO>();
        }
    }
}