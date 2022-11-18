using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.DTO.Orders.Category;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        protected readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<ShortCategoryDTO> Create(CreateCategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ShortCategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<CategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet("get-all-short")]
        public async Task<IEnumerable<ShortCategoryDTO>> GetAllShort()
        {
            return await _repository.GetAllShort();
        }

        [HttpPut("update")]
        public async Task<ShortCategoryDTO> Update(ShortCategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
