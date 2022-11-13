using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Hookahs;
using Replica.DTO.Hookahs.Hookah;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahController : ControllerBase
    {
        private readonly HookahRepository _repository;
        public HookahController(HookahRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<HookahDTO> Create([FromBody] HookahDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<HookahDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<HookahDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<HookahDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<HookahDTO> Update([FromBody] HookahDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
