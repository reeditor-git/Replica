using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repositories.Orders;
using Replica.Shared.Orders.Product;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        protected readonly ProductRepository _repository;
        public ProductsController(ProductRepository repository) => 
            _repository = repository;

        [HttpPost]
        public async Task<ProductDTO> Create(CreateProductDTO entity) => 
            await _repository.Create(entity);

        [HttpDelete("{id}")]
        public async Task<ProductDTO> Delete(Guid id) => 
            await _repository.Delete(id);

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(Guid id) => 
            await _repository.Get(id);

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll() => 
            await _repository.GetAll();

        [HttpPut]
        public async Task<ProductDTO> Update(ProductDTO entity) => 
            await _repository.Update(entity);
    }
}
