using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Interfaces;
using Replica.Shared.Subcategory;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubcategoriesController : ControllerBase
    {
        protected readonly ISubcategoryRepository _repository;
        public SubcategoriesController(ISubcategoryRepository repository) =>
            _repository = repository;

        [HttpPost]
        [Authorize]
        public async Task<SubcategoryDto> Create(CreateSubcategoryDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<SubcategoryDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<SubcategoryDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<SubcategoryDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut]
        [Authorize]
        public async Task<SubcategoryDto> Update(SubcategoryDto entity) =>
            await _repository.Update(entity);
    }
}
