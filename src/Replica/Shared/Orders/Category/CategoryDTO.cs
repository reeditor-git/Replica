using Replica.DTO.Base;
using Replica.DTO.Orders.Subcategory;

namespace Replica.DTO.Orders.Category
{
    public class CategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public ICollection<SubcategoryDTO>? Subcategories { get; set; }
    }
}
