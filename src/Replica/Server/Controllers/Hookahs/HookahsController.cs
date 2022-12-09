using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.Shared.Hookahs.Hookah;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahsController : ControllerBase
    {
        private readonly HookahRepository _repository;
        public HookahsController(HookahRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<HookahDTO> Create(CreateHookahDTO entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<HookahDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<HookahDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<HookahDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut]
        public async Task<HookahDTO> Update(HookahDTO entity) => 
            await _repository.Update(entity);
    }
}
