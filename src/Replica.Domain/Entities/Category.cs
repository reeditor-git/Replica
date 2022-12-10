namespace Replica.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public ICollection<Subcategory>? Subcategories { get; set; }
    }
}