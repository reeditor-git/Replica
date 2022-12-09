using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.GameZone;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameZonesController : ControllerBase
    {
        protected readonly GameZoneRepository _repository;
        public GameZonesController(GameZoneRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<GameZoneDTO> Create(CreateGameZoneDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<GameZoneDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<GameZoneDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<GameZoneDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("available")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllAvailable() => 
            await _repository.GetAllAvailable();

        [HttpGet("unavailable")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllUnavailable() => 
            await _repository.GetAllUnavailable();
        [HttpPut]
        public async Task<GameZoneDTO> Update(GameZoneDTO entity) => 
            await _repository.Update(entity);
    }
}
