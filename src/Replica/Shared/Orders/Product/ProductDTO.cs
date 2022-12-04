using Replica.Shared.Base;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Shared.Orders.Product
{
    public class ProductDTO : DTOBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public SubcategoryDTO? Subcategory { get; set; }

        public string Image { get; set; }
    }
}
