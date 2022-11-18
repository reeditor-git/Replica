using AutoMapper;
using Replica.Domain.Entities.Hookahs;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Hookahs.ComponentCategory;
using Replica.DTO.Hookahs.Hookah;
using Replica.DTO.Hookahs.HookahComponent;
using Replica.DTO.Orders.Category;
using Replica.DTO.Orders.GameZone;
using Replica.DTO.Orders.Order;
using Replica.DTO.Orders.Product;
using Replica.DTO.Orders.Subcategory;
using Replica.DTO.Orders.Table;

namespace Replica.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ComponentCategory, ComponentCategoryDTO>();
            CreateMap<ComponentCategoryDTO, ComponentCategory>();
            CreateMap<ComponentCategory, ShortComponentCategoryDTO>();
            CreateMap<ShortComponentCategoryDTO, ComponentCategory>();

            CreateMap<Hookah, HookahDTO>();
            CreateMap<HookahDTO, Hookah>();

            CreateMap<HookahComponent, HookahComponentDTO>();
            CreateMap<HookahComponentDTO, HookahComponent>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, ShortCategoryDTO>();
            CreateMap<ShortCategoryDTO, Category>();

            CreateMap<GameZone, GameZoneDTO>();
            CreateMap<GameZoneDTO, GameZone>();

            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();

            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<Subcategory, SubcategoryDTO>();
            CreateMap<SubcategoryDTO, Subcategory>();

            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, Table>();
        }
    }
}