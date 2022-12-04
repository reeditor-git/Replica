using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.Shared.Hookahs.ComponentCategory;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoryController : ControllerBase
    {
        private readonly ComponentCategoryRepository _repository;
        public ComponentCategoryController(ComponentCategoryRepository repository) => 
            _repository = repository;

        [HttpPost("create")]
        public async Task<ShortComponentCategoryDTO> Create(CreateComponentCategoryDTO entity) =>  
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<ShortComponentCategoryDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<ComponentCategoryDTO> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("get-all-short")]
        public async Task<IEnumerable<ShortComponentCategoryDTO>> GetAllShort() => 
            await _repository.GetAllShort();

        [HttpPut("update")]
        public async Task<ShortComponentCategoryDTO> Update(ShortComponentCategoryDTO entity) => 
            await _repository.Update(entity);
    }
}
