using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.DTO.Orders.Subcategory;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        protected readonly SubcategoryRepository _repository;
        public SubcategoryController(SubcategoryRepository repository) => _repository = repository;

        [HttpPost("create")]
        public async Task<SubcategoryDTO> Create(SubcategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("delete/{id}")]
        public async Task<SubcategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("get/{id}")]
        public async Task<SubcategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<SubcategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut("update")]
        public async Task<SubcategoryDTO> Update(SubcategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
