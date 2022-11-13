namespace Replica.DTO.Orders
{
    public class TableDTO : DTOBase
    {
        public int TableNumber { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }
    }
}
