using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Table;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TablesController : ControllerBase
    {
        protected readonly ITableRepository _repository;
        public TablesController(ITableRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<TableDto> Create(CreateTableDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<TableDto> Update(TableDto entity) =>
            await _repository.Update(entity);
    }
}
