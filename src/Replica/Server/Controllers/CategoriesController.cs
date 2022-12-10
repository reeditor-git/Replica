using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Category;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected readonly ICategoryRepository _repository;

        public CategoriesController(ICategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<ShortCategoryDto> Create(CreateCategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ShortCategoryDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<CategoryDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> GetAll() =>
            await _repository.GetAll();

        [HttpGet("short")]
        public async Task<IEnumerable<ShortCategoryDto>> GetAllShort() =>
            await _repository.GetAllShort();

        [HttpPut]
        [Authorize]
        public async Task<ShortCategoryDto> Update(ShortCategoryDto entity) =>
            await _repository.Update(entity);
    }
}
