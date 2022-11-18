using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.DTO.Hookahs.Hookah
{
    public class CreateHookahDTO
    {
        public bool AdditionalHose { get; set; }

        public ICollection<HookahComponentDTO> Components { get; set; }
    }
}
