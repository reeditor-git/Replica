using AutoMapper;
using Replica.Domain.Entities.Hookahs;
using Replica.Domain.Entities.Orders;
using Replica.Shared.Hookahs.ComponentCategory;
using Replica.Shared.Hookahs.Hookah;
using Replica.Shared.Hookahs.HookahComponent;
using Replica.Shared.Orders.Category;
using Replica.Shared.Orders.GameZone;
using Replica.Shared.Orders.Order;
using Replica.Shared.Orders.Product;
using Replica.Shared.Orders.Subcategory;
using Replica.Shared.Orders.Table;

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