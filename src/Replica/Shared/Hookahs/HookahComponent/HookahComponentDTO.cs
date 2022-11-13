using Replica.DTO.Hookahs.ComponentCategory;

namespace Replica.DTO.Hookahs.HookahComponent
{
    public class HookahComponentDTO : DTOBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public ShortComponentCategoryDTO Category { get; set; }
    }
}
