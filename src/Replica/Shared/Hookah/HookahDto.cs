using Replica.Shared.HookahComponent;

namespace Replica.Shared.Hookah
{
    public class HookahDto : DtoBase
    {
        public bool AdditionalHose { get; set; }

        public string Image { get; set; }

        public ICollection<HookahComponentDto> Components { get; set; }
    }
}
