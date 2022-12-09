namespace Replica.Domain.Entities
{
    public class Order : EntityBase
    {
        public User User { get; set; }

        public Table? Table { get; set; }

        public GameZone? GameZone { get; set; }

        public ICollection<Product>? Products { get; set; }

        public ICollection<Hookah>? Hookahs { get; set; }

        public string? Comment { get; set; }

        public bool Paid { get; set; }
    }
}
