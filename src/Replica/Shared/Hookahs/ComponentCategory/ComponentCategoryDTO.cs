using Replica.DTO.Base;
using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.DTO.Hookahs.ComponentCategory
{
    public class ComponentCategoryDTO : DTOBase
    {
        public string Name { get; set; }

        public ICollection<HookahComponentDTO>? Components { get; set; }
    }
}
