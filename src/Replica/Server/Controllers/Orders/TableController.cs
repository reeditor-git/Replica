using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Table;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        protected readonly TableRepository _repository;
        public TableController(TableRepository repository) => 
            _repository = repository;

        [HttpPost("create")]
        public async Task<TableDTO> Create(TableDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<TableDTO> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<TableDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<TableDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut("update")]
        public async Task<TableDTO> Update(TableDTO entity) =>
            await _repository.Update(entity);
    }
}
