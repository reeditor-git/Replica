namespace Replica.Domain.Entities
{
    public class GameZone : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }

        public string Image { get; set; }
    }
}
