using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Hookahs
{
    public class ComponentCategory : EntityBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<HookahComponent>? Components { get; set; }
    }
}
