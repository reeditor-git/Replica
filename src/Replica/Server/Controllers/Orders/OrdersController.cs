using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Order;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        protected readonly OrderRepository _repository;
        public OrdersController(OrderRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<OrderDTO> Create(CreateOrderDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<OrderDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("user/{id}")]
        public async Task<IEnumerable<OrderDTO>> GetAllByUser(Guid id) =>
            await _repository.GetAllByUser(id);

        [HttpPut]
        public async Task<OrderDTO> Update(OrderDTO entity) => 
            await _repository.Update(entity);
    }
}
