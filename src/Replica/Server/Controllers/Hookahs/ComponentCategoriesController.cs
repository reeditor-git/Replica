using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.Shared.Hookahs.ComponentCategory;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoriesController : ControllerBase
    {
        private readonly ComponentCategoryRepository _repository;
        public ComponentCategoriesController(ComponentCategoryRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<ShortComponentCategoryDTO> Create(CreateComponentCategoryDTO entity) =>  
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<ShortComponentCategoryDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<ComponentCategoryDTO> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("short")]
        public async Task<IEnumerable<ShortComponentCategoryDTO>> GetAllShort() => 
            await _repository.GetAllShort();

        [HttpPut]
        public async Task<ShortComponentCategoryDTO> Update(ShortComponentCategoryDTO entity) => 
            await _repository.Update(entity);
    }
}
