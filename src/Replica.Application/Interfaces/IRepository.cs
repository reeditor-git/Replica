namespace Replica.Application.Interfaces
{
    public interface IRepository<T>
    {

        public void Create(T entity);

        public void Delete(T entity);

        public T Get(int id);

        public IEnumerable<T> GetAll();

        public void Update(T entity);
    }
}
