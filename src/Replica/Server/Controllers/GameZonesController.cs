using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.GameZone;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameZonesController : ControllerBase
    {
        protected readonly GameZoneRepository _repository;
        public GameZonesController(GameZoneRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<GameZoneDto> Create(CreateGameZoneDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<GameZoneDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<GameZoneDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<GameZoneDto>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("available")]
        public async Task<IEnumerable<GameZoneDto>> GetAllAvailable() =>
            await _repository.GetAllAvailable();

        [HttpGet("unavailable")]
        public async Task<IEnumerable<GameZoneDto>> GetAllUnavailable() =>
            await _repository.GetAllUnavailable();
        [HttpPut]
        public async Task<GameZoneDto> Update(GameZoneDto entity) =>
            await _repository.Update(entity);
    }
}
