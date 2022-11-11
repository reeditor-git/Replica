using Replica.Application.Interfaces;
using Replica.DTO.Orders;

namespace Replica.Application.Repository.Orders
{
    public class OrderRepository : IRepository<OrderDTO>
    {
        public void Create(OrderDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OrderDTO entity)
        {
            throw new NotImplementedException();
        }

        public OrderDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(OrderDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
