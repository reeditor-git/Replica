namespace Replica.Domain.Entities
{
    public class Hookah : EntityBase
    {
        public bool AdditionalHose { get; set; }

        public string Image { get; set; }

        public decimal Price { get; set; } 

        public ICollection<HookahComponent> Components { get; set; }
    }
}
