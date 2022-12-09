using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Shared.Hookahs.Hookah
{
    public class HookahDto : DtoBase
    {
        public bool AdditionalHose { get; set; }

        public string Image { get; set; }

        public ICollection<HookahComponentDto> Components { get; set; }
    }
}
