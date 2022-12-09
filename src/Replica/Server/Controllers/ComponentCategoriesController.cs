using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.ComponentCategory;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoriesController : ControllerBase
    {
        private readonly ComponentCategoryRepository _repository;
        public ComponentCategoriesController(ComponentCategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<ShortComponentCategoryDto> Create(CreateComponentCategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<ShortComponentCategoryDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<ComponentCategoryDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<ComponentCategoryDto>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("short")]
        public async Task<IEnumerable<ShortComponentCategoryDto>> GetAllShort() =>
            await _repository.GetAllShort();

        [HttpPut]
        public async Task<ShortComponentCategoryDto> Update(ShortComponentCategoryDto entity) =>
            await _repository.Update(entity);
    }
}
