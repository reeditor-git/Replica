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
            //Category
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, ShortCategoryDto>();
            CreateMap<ShortCategoryDto, Category>();

            //ComponentCategory
            CreateMap<ComponentCategory, ComponentCategoryDto>();
            CreateMap<ComponentCategoryDto, ComponentCategory>();
            CreateMap<ComponentCategory, ShortComponentCategoryDto>();
            CreateMap<ShortComponentCategoryDto, ComponentCategory>();

            //GameZone
            CreateMap<GameZone, GameZoneDto>();
            CreateMap<GameZoneDto, GameZone>();

            //HookahComponent
            CreateMap<HookahComponent, HookahComponentDto>();
            CreateMap<HookahComponentDto, HookahComponent>();

            //Hookah
            CreateMap<Hookah, HookahDto>();
            CreateMap<HookahDto, Hookah>();

            //Order
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            //Product
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            //Subcategory
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<SubcategoryDto, Subcategory>();

            //Table
            CreateMap<Table, TableDto>();
            CreateMap<TableDto, Table>();
        }
    }
}