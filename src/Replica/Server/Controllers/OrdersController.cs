using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Order;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        protected readonly IOrderRepository _repository;
        public OrdersController(IOrderRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<OrderDto> Create(CreateOrderDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<OrderDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("user/{id}")]
        public async Task<IEnumerable<OrderDto>> GetAllByUser(Guid id) =>
            await _repository.GetAllByUser(id);

        [HttpPut]
        public async Task<OrderDto> Update(OrderDto entity) =>
            await _repository.Update(entity);
    }
}
