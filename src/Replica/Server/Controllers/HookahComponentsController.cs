using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.HookahComponent;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahComponentsController : ControllerBase
    {
        private readonly IHookahComponentRepository _repository;
        public HookahComponentsController(IHookahComponentRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<HookahComponentDto> Create(CreateHookahComponentDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<HookahComponentDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<HookahComponentDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<HookahComponentDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut]
        [Authorize]
        public async Task<HookahComponentDto> Update(HookahComponentDto entity) =>
            await _repository.Update(entity);
    }
}
