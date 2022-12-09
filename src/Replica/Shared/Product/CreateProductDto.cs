namespace Replica.Shared.Product
{
    public class CreateProductDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }

        public string Image { get; set; }
    }
}
