using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Hookahs;
using Replica.DTO.Hookahs.ComponentCategory;

namespace Replica.Server.Controllers.Hookahs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoryController : ControllerBase
    {
        private readonly ComponentCategoryRepository _repository;
        public ComponentCategoryController(ComponentCategoryRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<ShortComponentCategoryDTO> Create(CreateComponentCategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ShortComponentCategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<ComponentCategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("get-all-short")]
        public async Task<IEnumerable<ShortComponentCategoryDTO>> GetAllShort()
        {
            return await _repository.GetAllShort();
        }

        [HttpPut("update")]
        public async Task<ShortComponentCategoryDTO> Update(ShortComponentCategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
