using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders.Category;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        protected readonly CategoryRepository _repository;

        public CategoryController(CategoryRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<CategoryDTO> Create(CategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<CategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<CategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<CategoryDTO> Update(CategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
