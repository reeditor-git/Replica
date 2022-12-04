using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Order;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        protected readonly OrderRepository _repository;
        public OrderController(OrderRepository repository) => 
            _repository = repository;

        [HttpPost("create")]
        public async Task<OrderDTO> Create(CreateOrderDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<OrderDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<OrderDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<OrderDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut("update")]
        public async Task<OrderDTO> Update(OrderDTO entity) => 
            await _repository.Update(entity);
    }
}
