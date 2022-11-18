using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.DTO.Orders.Order;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        protected readonly OrderRepository _repository;
        public OrderController(OrderRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<OrderDTO> Create(OrderDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<OrderDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<OrderDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut("update")]
        public async Task<OrderDTO> Update(OrderDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
