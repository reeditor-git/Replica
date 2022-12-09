using Replica.Shared.Orders.Subcategory;

namespace Replica.Shared.Orders.Product
{
    public class ProductDto : DtoBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public SubcategoryDto? Subcategory { get; set; }

        public string Image { get; set; }
    }
}
