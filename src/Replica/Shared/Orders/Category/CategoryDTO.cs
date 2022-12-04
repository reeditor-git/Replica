using Replica.Shared.Base;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Shared.Orders.Category
{
    public class CategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<SubcategoryDTO>? Subcategories { get; set; }
    }
}
