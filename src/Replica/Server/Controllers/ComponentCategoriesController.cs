using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.ComponentCategory;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentCategoriesController : ControllerBase
    {
        private readonly IComponentCategoryRepository _repository;
        public ComponentCategoriesController(IComponentCategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<ShortComponentCategoryDto> Create(CreateComponentCategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
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
        [Authorize]
        public async Task<ShortComponentCategoryDto> Update(ShortComponentCategoryDto entity) =>
            await _repository.Update(entity);
    }
}
