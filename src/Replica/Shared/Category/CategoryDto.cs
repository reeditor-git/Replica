using Replica.Shared.Subcategory;

namespace Replica.Shared.Category
{
    public class CategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<SubcategoryDto>? Subcategories { get; set; }
    }
}
