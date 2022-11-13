using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Hookahs;
using Replica.DTO.Hookahs.ComponentCategory;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoryController : ControllerBase
    {
        private readonly ComponentCategoryRepository _repository;
        public ComponentCategoryController(ComponentCategoryRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<ComponentCategoryDTO> Create(ShortComponentCategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ComponentCategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<ComponentCategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<ComponentCategoryDTO> Update([FromBody] ShortComponentCategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
