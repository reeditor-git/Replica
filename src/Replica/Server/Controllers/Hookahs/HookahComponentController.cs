using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahComponentController : ControllerBase
    {
        private readonly HookahComponentRepository _repository;
        public HookahComponentController(HookahComponentRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<HookahComponentDTO> Create(CreateHookahComponentDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<HookahComponentDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<HookahComponentDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<HookahComponentDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut("update")]
        public async Task<HookahComponentDTO> Update(HookahComponentDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
