using Replica.Shared.Base;

namespace Replica.Shared.Hookahs.HookahComponent
{
    public class CreateHookahComponentDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public Guid CategoryId { get; set; }
    }
}
