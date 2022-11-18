using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.DTO.Orders.Table;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        protected readonly TableRepository _repository;
        public TableController(TableRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<TableDTO> Create(TableDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<TableDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<TableDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<TableDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut("update")]
        public async Task<TableDTO> Update(TableDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
