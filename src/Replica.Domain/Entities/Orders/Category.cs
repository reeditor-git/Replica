using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Orders
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public ICollection<Subcategory> Subcategories { get; set; }
    }
}