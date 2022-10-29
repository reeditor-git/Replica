using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Rent
{
    public class GameZone : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }
    }
}
