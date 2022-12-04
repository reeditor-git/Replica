using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.GameZone;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameZoneController : ControllerBase
    {
        protected readonly GameZoneRepository _repository;
        public GameZoneController(GameZoneRepository repository) => 
            _repository = repository;

        [HttpPost("create")]
        public async Task<GameZoneDTO> Create(CreateGameZoneDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<GameZoneDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<GameZoneDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<GameZoneDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("get-all-available")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllAvailable() => 
            await _repository.GetAllAvailable();

        [HttpGet("get-all-unavailable")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllUnavailable() => 
            await _repository.GetAllUnavailable();
        [HttpPut("update")]
        public async Task<GameZoneDTO> Update(GameZoneDTO entity) => 
            await _repository.Update(entity);
    }
}
