namespace Replica.Domain.Entities
{
    public class RefreshToken : EntityBase
    {
        public string Token { get; set; }

        public DateTime ExpiryDate { get; set; }

        public User User { get; set; }
    }
}