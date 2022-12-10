using AutoMapper;
using Replica.Domain.Entities;
using Replica.Shared.Category;
using Replica.Shared.ComponentCategory;
using Replica.Shared.GameZone;
using Replica.Shared.Hookah;
using Replica.Shared.HookahComponent;
using Replica.Shared.Order;
using Replica.Shared.Product;
using Replica.Shared.Subcategory;
using Replica.Shared.Table;

namespace Replica.Server.Profiles
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