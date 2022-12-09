using Replica.Shared.Hookahs.Hookah;
using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Order
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }

        public Guid? TableId { get; set; }

        public Guid? GameZoneId { get; set; }

        public ICollection<ProductDto>? Products { get; set; }

        public ICollection<HookahDto>? Hookahs { get; set; } 

        public string? Comment { get; set; }

        public bool Paid { get; set; }
    }
}
