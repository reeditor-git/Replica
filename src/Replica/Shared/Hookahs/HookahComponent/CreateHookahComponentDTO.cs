using Replica.DTO.Base;

namespace Replica.DTO.Hookahs.HookahComponent
{
    public class CreateHookahComponentDTO : DTOBase
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
    }
}
