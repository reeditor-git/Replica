using Replica.DTO.Base;
using Replica.DTO.Orders.Category;
using Replica.DTO.Orders.Product;

namespace Replica.DTO.Orders.Subcategory
{
    public class SubcategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public CategoryDTO Category { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}
