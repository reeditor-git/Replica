using Replica.Shared.HookahComponent;

namespace Replica.Shared.ComponentCategory
{
    public class ComponentCategoryDto : DtoBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public ICollection<HookahComponentDto>? Components { get; set; }
    }
}
