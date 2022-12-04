namespace Replica.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, Object key)
            : base($"Entity '{name}' with ID {key} not found") { }
    }
}
