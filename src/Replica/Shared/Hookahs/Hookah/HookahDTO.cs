using Replica.Shared.Base;
using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Shared.Hookahs.Hookah
{
    public class HookahDTO : DTOBase
    {
        public bool AdditionalHose { get; set; }

        public string Image { get; set; }

        public ICollection<HookahComponentDTO> Components { get; set; }
    }
}
