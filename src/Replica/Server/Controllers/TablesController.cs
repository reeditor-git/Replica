using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Orders.Table;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        protected readonly TableRepository _repository;
        public TablesController(TableRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<TableDto> Create(CreateTableDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<TableDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<TableDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<TableDto>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("available")]
        public async Task<IEnumerable<TableDto>> GetAllAvailable() =>
            await _repository.GetAllAvailable();

        [HttpGet("unavailable")]
        public async Task<IEnumerable<TableDto>> GetAllUnavailable() =>
            await _repository.GetAllUnavailable();

        [HttpPut]
        public async Task<TableDto> Update(TableDto entity) =>
            await _repository.Update(entity);
    }
}
