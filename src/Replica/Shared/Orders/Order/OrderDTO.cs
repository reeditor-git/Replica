using Replica.Shared.Base;
using Replica.Shared.Hookahs.Hookah;
using Replica.Shared.Orders.GameZone;
using Replica.Shared.Orders.Product;
using Replica.Shared.Orders.Table;

namespace Replica.Shared.Orders.Order
{
    public class OrderDTO : DTOBase
    {
        public Guid UserId { get; set; }

        public TableDTO? Table { get; set; }

        public GameZoneDTO? GameZone { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }

        public ICollection<HookahDTO>? Hookahs { get; set; }

        public string? Comment { get; set; }

        public bool Paid { get; set; }
    }
}
