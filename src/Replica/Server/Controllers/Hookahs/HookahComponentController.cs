using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Hookahs;
using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class HookahComponentController : ControllerBase
    {
        private readonly HookahComponentRepository _repository;
        public HookahComponentController(HookahComponentRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<HookahComponentDTO> Create([FromBody] HookahComponentDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<HookahComponentDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<HookahComponentDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<HookahComponentDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<HookahComponentDTO> Update([FromBody] HookahComponentDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
