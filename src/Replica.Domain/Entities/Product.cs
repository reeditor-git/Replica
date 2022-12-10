namespace Replica.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }

        public Subcategory Subcategory { get; set; }

        public string Image { get; set; }
    }
}
