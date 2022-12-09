using AutoMapper;
using Replica.Domain.Entities;
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
            CreateMap<ComponentCategory, ComponentCategoryDto>();
            CreateMap<ComponentCategoryDto, ComponentCategory>();
            CreateMap<ComponentCategory, ShortComponentCategoryDto>();
            CreateMap<ShortComponentCategoryDto, ComponentCategory>();

            CreateMap<Hookah, HookahDto>();
            CreateMap<HookahDto, Hookah>();

            CreateMap<HookahComponent, HookahComponentDto>();
            CreateMap<HookahComponentDto, HookahComponent>();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, ShortCategoryDto>();
            CreateMap<ShortCategoryDto, Category>();

            CreateMap<GameZone, GameZoneDto>();
            CreateMap<GameZoneDto, GameZone>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<SubcategoryDto, Subcategory>();

            CreateMap<Table, TableDto>();
            CreateMap<TableDto, Table>();
        }
    }
}