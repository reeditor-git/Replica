using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Category;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        protected readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository) =>
            _repository = repository;

        [HttpPost("create")]
        public async Task<ShortCategoryDTO> Create(CreateCategoryDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<ShortCategoryDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<CategoryDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<CategoryDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpGet("get-all-short")]
        public async Task<IEnumerable<ShortCategoryDTO>> GetAllShort() => 
            await _repository.GetAllShort();

        [HttpPut("update")]
        public async Task<ShortCategoryDTO> Update(ShortCategoryDTO entity) => 
            await _repository.Update(entity);
    }
}
