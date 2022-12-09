using Replica.Shared.Orders.Category;
using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Subcategory
{
    public class SubcategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<ProductDto>? Products { get; set; }
    }
}
