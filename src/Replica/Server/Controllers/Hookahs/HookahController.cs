using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.DTO.Hookahs.Hookah;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahController : ControllerBase
    {
        private readonly HookahRepository _repository;
        public HookahController(HookahRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<HookahDTO> Create(CreateHookahDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<HookahDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<HookahDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<HookahDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut("update")]
        public async Task<HookahDTO> Update(HookahDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
