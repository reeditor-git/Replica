using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Hookahs
{
    public class Hookah : EntityBase
    {
        public bool AdditionalHose { get; set; }

        public ICollection<HookahComponent> Components { get; set; }
    }
}
