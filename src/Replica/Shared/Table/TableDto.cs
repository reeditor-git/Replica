namespace Replica.Shared.Orders.Table
{
    public class TableDto : DtoBase
    {
        public int TableNumber { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public int SeatingCapacity { get; set; }

        public string Image { get; set; }
    }
}
