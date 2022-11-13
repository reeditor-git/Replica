using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders.Order;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        protected readonly OrderRepository _repository;
        public OrderController(OrderRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<OrderDTO> Create(OrderDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<OrderDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<OrderDTO> Update(OrderDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
