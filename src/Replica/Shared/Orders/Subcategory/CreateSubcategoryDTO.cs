using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Subcategory
{
    public class CreateSubcategoryDTO
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public Guid CategoryID { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }
    }
}
