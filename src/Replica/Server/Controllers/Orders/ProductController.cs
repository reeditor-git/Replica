using Microsoft.AspNetCore.Mvc;
using Replica.Application.Repository.Orders;
using Replica.DTO.Orders;

namespace Replica.Server.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly ProductRepository _repository;
        public ProductController(ProductRepository repository) => _repository = repository;

        [HttpPost]
        public async Task<ProductDTO> Create(ProductDTO entity)
        {
            return await _repository.Create(entity);
        }

        [HttpDelete("{id}")]
        public async Task<ProductDTO> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<ProductDTO> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpPut]
        public async Task<ProductDTO> Update(ProductDTO entity)
        {
            return await _repository.Update(entity);
        }
    }
}
