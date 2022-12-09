using Replica.Shared.Hookahs.ComponentCategory;

namespace Replica.Shared.Hookahs.HookahComponent
{
    public class HookahComponentDto : DtoBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ShortComponentCategoryDto Category { get; set; }
    }
}
