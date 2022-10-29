using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Orders
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Category Category { get; set; }

        public Subcategory Subcategory { get; set; }
    }
}
