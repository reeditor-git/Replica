namespace Replica.DTO.Orders.GameZone
{
    public class CreateGameZoneDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }
    }
}
