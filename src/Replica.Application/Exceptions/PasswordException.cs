namespace Replica.Application.Exceptions
{
    public class PasswordException : Exception
    {
        public PasswordException(Object key)
             : base($"Invalid password for user {key}.") { }
    }
}
