using Replica.Shared.Base;
using Replica.Shared.Hookahs.ComponentCategory;

namespace Replica.Shared.Hookahs.HookahComponent
{
    public class HookahComponentDTO : DTOBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public ShortComponentCategoryDTO Category { get; set; }
    }
}
