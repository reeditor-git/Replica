using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Subcategory
{
    public class CreateSubcategoryDto
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public Guid CategoryId { get; set; }

        public ICollection<ProductDto>? Products { get; set; }
    }
}
