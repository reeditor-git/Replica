using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoryController : ControllerBase
    {
        protected readonly SubcategoryRepository _repository;
        public SubcategoryController(SubcategoryRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<SubcategoryDTO> Create(SubcategoryDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<SubcategoryDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<SubcategoryDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<SubcategoryDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<SubcategoryDTO> Update(SubcategoryDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
