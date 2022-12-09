namespace Replica.Shared.Users.Login
{
    public class LoginDTO
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
