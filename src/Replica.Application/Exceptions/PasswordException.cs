namespace Replica.Application.Exceptions
{
    public class PasswordException : ApplicationException
    {
        public PasswordException(Object key)
             : base($"Invalid password for user {key}.") { }
    }
}
