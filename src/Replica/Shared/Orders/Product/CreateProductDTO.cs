namespace Replica.Shared.Orders.Product
{
    public class CreateProductDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Guid SubcategoryId { get; set; }

        public string Image { get; set; }
    }
}
