using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.DTO.Hookahs.Hookah
{
    public class HookahDTO : DTOBase
    {
        public bool AdditionalHose { get; set; }

        public ICollection<HookahComponentDTO> Components { get; set; }
    }
}
