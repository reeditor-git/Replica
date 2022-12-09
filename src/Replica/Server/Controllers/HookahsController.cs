using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Hookahs.Hookah;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahsController : ControllerBase
    {
        private readonly HookahRepository _repository;
        public HookahsController(HookahRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<HookahDto> Create(CreateHookahDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<HookahDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<HookahDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<HookahDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut]
        public async Task<HookahDto> Update(HookahDto entity) =>
            await _repository.Update(entity);
    }
}
