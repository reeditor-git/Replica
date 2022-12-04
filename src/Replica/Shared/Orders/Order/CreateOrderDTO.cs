using Replica.Shared.Hookahs.Hookah;
using Replica.Shared.Orders.Product;

namespace Replica.Shared.Orders.Order
{
    public class CreateOrderDTO
    {
        public Guid UserId { get; set; }

        public Guid? TableId { get; set; }

        public Guid? GameZoneId { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }

        public ICollection<HookahDTO>? Hookahs { get; set; } 

        public string? Comment { get; set; }

        public bool Paid { get; set; }
    }
}
