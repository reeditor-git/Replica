using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Users
{
    public class UserRole : EntityBase
    {
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}