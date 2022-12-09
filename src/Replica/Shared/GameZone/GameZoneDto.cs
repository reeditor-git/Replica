namespace Replica.Shared.Orders.GameZone
{
    public class GameZoneDto : DtoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }

        public string Image { get; set; }
    }
}
