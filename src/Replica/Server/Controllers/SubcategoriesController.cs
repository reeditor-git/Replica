using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        protected readonly SubcategoryRepository _repository;
        public SubcategoriesController(SubcategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        public async Task<SubcategoryDto> Create(CreateSubcategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<SubcategoryDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<SubcategoryDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<SubcategoryDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut]
        public async Task<SubcategoryDto> Update(SubcategoryDto entity) =>
            await _repository.Update(entity);
    }
}
