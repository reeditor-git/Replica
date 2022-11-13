using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders.GameZone;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameZoneController : ControllerBase
    {
        protected readonly GameZoneRepository _repository;
        public GameZoneController(GameZoneRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<GameZoneDTO> Create(GameZoneDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<GameZoneDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<GameZoneDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<GameZoneDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<GameZoneDTO> Update(GameZoneDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
