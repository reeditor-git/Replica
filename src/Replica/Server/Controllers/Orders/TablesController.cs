using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.GameZone;
using Replica.Shared.Orders.Table;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        protected readonly TableRepository _repository;
        public TablesController(TableRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<TableDTO> Create(CreateTableDTO entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<TableDTO> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<TableDTO> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<TableDTO>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("available")]
        public async Task<IEnumerable<TableDTO>> GetAllAvailable() =>
            await _repository.GetAllAvailable();

        [HttpGet("unavailable")]
        public async Task<IEnumerable<TableDTO>> GetAllUnavailable() =>
            await _repository.GetAllUnavailable();

        [HttpPut]
        public async Task<TableDTO> Update(TableDTO entity) =>
            await _repository.Update(entity);
    }
}
