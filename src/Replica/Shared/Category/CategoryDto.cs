using Replica.Shared.Orders.Subcategory;

namespace Replica.Shared.Orders.Category
{
    public class CategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<SubcategoryDto>? Subcategories { get; set; }
    }
}
