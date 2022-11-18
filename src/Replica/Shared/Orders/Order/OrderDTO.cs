using Replica.DTO.Base;
using Replica.DTO.Hookahs.Hookah;
using Replica.DTO.Orders.GameZone;
using Replica.DTO.Orders.Product;
using Replica.DTO.Orders.Table;

namespace Replica.DTO.Orders.Order
{
    public class OrderDTO : DTOBase
    {
        public Guid UserId { get; set; }

        public TableDTO? Table { get; set; }

        public GameZoneDTO? GameZone { get; set; }

        public ICollection<ProductDTO>? Products { get; set; }

        public ICollection<HookahDTO> Hookahs { get; set; }

        public string Comment { get; set; }
    }
}
