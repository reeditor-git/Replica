using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class TableController : ControllerBase
    {
        protected readonly TableRepository _repository;
        public TableController(TableRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<TableDTO> Create(TableDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<TableDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<TableDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<TableDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<TableDTO> Update(TableDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
