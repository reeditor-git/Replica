namespace Replica.Domain.Entities.Hookahs
{
    public class Hookah
    {
        public bool AdditionalHose { get; set; }

        public ICollection<HookahComponent> Components { get; set; }
    }
}
