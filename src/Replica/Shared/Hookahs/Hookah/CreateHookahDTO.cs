using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Shared.Hookahs.Hookah
{
    public class CreateHookahDTO
    {
        public bool AdditionalHose { get; set; }

        public string Image { get; set; }

        public ICollection<HookahComponentDTO> Components { get; set; }
    }
}
