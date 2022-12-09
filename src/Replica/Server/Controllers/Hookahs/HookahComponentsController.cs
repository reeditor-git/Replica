using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahComponentsController : ControllerBase
    {
        private readonly HookahComponentRepository _repository;
        public HookahComponentsController(HookahComponentRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<HookahComponentDTO> Create(CreateHookahComponentDTO entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<HookahComponentDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<HookahComponentDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<HookahComponentDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut]
        public async Task<HookahComponentDTO> Update(HookahComponentDTO entity) => 
            await _repository.Update(entity);
    }
}
