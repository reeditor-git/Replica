using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        protected readonly SubcategoryRepository _repository;
        public SubcategoriesController(SubcategoryRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<SubcategoryDTO> Create(CreateSubcategoryDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<SubcategoryDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<SubcategoryDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<SubcategoryDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut]
        public async Task<SubcategoryDTO> Update(SubcategoryDTO entity) => 
            await _repository.Update(entity);
    }
}
