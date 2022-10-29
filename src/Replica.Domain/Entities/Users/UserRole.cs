namespace Replica.Domain.Entities.Users
{
    public class UserRole
    {
        public string Name { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}