using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Category;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        protected readonly CategoryRepository _repository;

        public CategoriesController(CategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<ShortCategoryDTO> Create(CreateCategoryDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<ShortCategoryDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<CategoryDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("short")]
        public async Task<IEnumerable<ShortCategoryDTO>> GetAllShort() => 
            await _repository.GetAllShort();

        [HttpPut]
        public async Task<ShortCategoryDTO> Update(ShortCategoryDTO entity) => 
            await _repository.Update(entity);
    }
}
