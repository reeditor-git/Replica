namespace Replica.Domain.Entities
{
    public class RefreshToken : EntityBase
    {
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }
    }
}