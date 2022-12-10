namespace Replica.Domain.Entities
{
    public class Subcategory : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public Guid CategoryId { get; set; }

        public Category Category { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}