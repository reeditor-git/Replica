namespace Replica.Shared.Login
{
    public class LoginDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
    }
}
