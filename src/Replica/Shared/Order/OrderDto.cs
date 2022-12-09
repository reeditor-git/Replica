using Replica.Shared.Hookahs.Hookah;
using Replica.Shared.Orders.GameZone;
using Replica.Shared.Orders.Product;
using Replica.Shared.Orders.Table;

namespace Replica.Shared.Orders.Order
{
    public class OrderDto : DtoBase
    {
        public Guid UserId { get; set; }

        public TableDto? Table { get; set; }

        public GameZoneDto? GameZone { get; set; }

        public ICollection<ProductDto>? Products { get; set; }

        public ICollection<HookahDto>? Hookahs { get; set; }

        public string? Comment { get; set; }

        public bool Paid { get; set; }
    }
}
