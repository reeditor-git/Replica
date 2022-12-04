using Replica.Shared.Base;
using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Shared.Hookahs.ComponentCategory
{
    public class ComponentCategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<HookahComponentDTO>? Components { get; set; }
    }
}
