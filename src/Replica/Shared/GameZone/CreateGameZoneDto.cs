namespace Replica.Shared.Orders.GameZone
{
    public class CreateGameZoneDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int SeatingCapacity { get; set; }

        public string Image { get; set; }
    }
}
