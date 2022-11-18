using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.DTO.Orders.GameZone;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameZoneController : ControllerBase
    {
        protected readonly GameZoneRepository _repository;
        public GameZoneController(GameZoneRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<GameZoneDTO> Create(CreateGameZoneDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<GameZoneDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<GameZoneDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<GameZoneDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("get-all-available")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllAvailable()
        {
            return await _repository.GetAllAvailable();
        }

        [HttpGet("get-all-unavailable")]
        public async Task<IEnumerable<GameZoneDTO>> GetAllUnavailable()
        {
            return await _repository.GetAllUnavailable();
        }
        [HttpPut("update")]
        public async Task<GameZoneDTO> Update(GameZoneDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
