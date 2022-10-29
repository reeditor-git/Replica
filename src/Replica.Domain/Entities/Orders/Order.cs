using Replica.Domain.Entities.Base;
using Replica.Domain.Entities.Rent;
using Replica.Domain.Entities.Users;

namespace Replica.Domain.Entities.Orders
{
    public class Order : EntityBase
    {
        public User User { get; set; }

        public Table? Table { get; set; }

        public GameZone? GameZone { get; set; }

        public ICollection<Product>? Products { get; set; }

        public string Comment { get; set; }
    }
}
