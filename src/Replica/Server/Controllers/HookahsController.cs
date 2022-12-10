using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Hookah;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahsController : ControllerBase
    {
        private readonly IHookahRepository _repository;
        public HookahsController(IHookahRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<HookahDto> Create(CreateHookahDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<HookahDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<HookahDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<HookahDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut]
        [Authorize]
        public async Task<HookahDto> Update(HookahDto entity) =>
            await _repository.Update(entity);
    }
}
