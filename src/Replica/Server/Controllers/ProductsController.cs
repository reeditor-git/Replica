using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories;
using Replica.Shared.Product;

namespace Replica.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        protected readonly ProductRepository _repository;
        public ProductsController(ProductRepository repository) =>
            _repository = repository;

        [HttpPost, Authorize]
        public async Task<ProductDto> Create(CreateProductDto entity) =>
            await _repository.Create(entity);

        [HttpDelete("{id}"), Authorize]
        public async Task<ProductDto> Delete(Guid id) =>
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<ProductDto> Get(Guid id) =>
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAll() =>
            await _repository.GetAll();

        [HttpPut, Authorize]
        public async Task<ProductDto> Update(ProductDto entity) =>
            await _repository.Update(entity);
    }
}
