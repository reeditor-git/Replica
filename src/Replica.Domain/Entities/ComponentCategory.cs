namespace Replica.Domain.Entities
{
    public class ComponentCategory : EntityBase
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }

        public ICollection<HookahComponent>? Components { get; set; }
    }
}
