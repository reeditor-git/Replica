namespace Replica.Application.Exceptions
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException(Object key)
            : base($"User with email {key} not found") { }
    }
}
