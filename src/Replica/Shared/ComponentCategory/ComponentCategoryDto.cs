using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Shared.Hookahs.ComponentCategory
{
    public class ComponentCategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Icon { get; set; }

        public ICollection<HookahComponentDto>? Components { get; set; }
    }
}
