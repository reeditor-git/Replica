using Replica.DTO.Base;
using Replica.DTO.Orders.Subcategory;

namespace Replica.DTO.Orders.Product
{
    public class ProductDTO : DTOBase
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public SubcategoryDTO? Subcategory { get; set; }
    }
}
