using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Hookahs
{
    public class HookahComponent : EntityBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ComponentCategory Category { get; set; }
    }
}
