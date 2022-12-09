using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Orders.Category;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected readonly CategoryRepository _repository;

        public CategoriesController(CategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<ShortCategoryDto> Create(CreateCategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
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
        public async Task<ShortCategoryDto> Update(ShortCategoryDto entity) =>
            await _repository.Update(entity);
    }
}
