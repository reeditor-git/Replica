using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Orders
{
    public class Table : EntityBase
    {
        public int TableNumber { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }
    }
}
