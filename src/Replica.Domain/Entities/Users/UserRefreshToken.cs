using Replica.Domain.Entities.Base;

namespace Replica.Domain.Entities.Users
{
    public class UserRefreshToken : EntityBase
    {
        public string RefreshToken { get; set; }

        public DateTime ExpiryDate { get; set; }

        public User User { get; set; }
    }
}