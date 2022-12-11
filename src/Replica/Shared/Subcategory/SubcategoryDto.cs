using Replica.Shared.Category;
using Replica.Shared.Product;

namespace Replica.Shared.Subcategory
{
    public class SubcategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public CategoryDto Category { get; set; }

        public ICollection<ProductDto>? Products { get; set; }
    }
}
