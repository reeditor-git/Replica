using Replica.Shared.Hookah;
using Replica.Shared.GameZone;
using Replica.Shared.Product;
using Replica.Shared.Table;

namespace Replica.Shared.Order
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
