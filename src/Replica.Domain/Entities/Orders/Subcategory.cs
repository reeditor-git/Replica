using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Orders
{
    public class Subcategory : EntityBase
    {
        public string Name { get; set; }

        public Category Category { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}