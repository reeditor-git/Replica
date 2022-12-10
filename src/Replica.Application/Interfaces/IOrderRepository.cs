using Replica.Shared.Order;

namespace Replica.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderDto> Create(CreateOrderDto entity);
        Task<OrderDto> Delete(Guid id);
        Task<OrderDto> Get(Guid id);
        Task<IEnumerable<OrderDto>> GetAll();
        Task<IEnumerable<OrderDto>> GetAllByUser(Guid id);
        Task<OrderDto> Update(OrderDto entity);
    }
}