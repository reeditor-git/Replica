using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Product;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly ProductRepository _repository;
        public ProductController(ProductRepository repository) => 
            _repository = repository;

        [HttpPost("create")]
        public async Task<ProductDTO> Create(ProductDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("delete/{id}")]
        public async Task<ProductDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("get/{id}")]
        public async Task<ProductDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet("get-all")]
        public async Task<IEnumerable<ProductDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut("update")]
        public async Task<ProductDTO> Update(ProductDTO entity) => 
            await _repository.Update(entity);
    }
}
