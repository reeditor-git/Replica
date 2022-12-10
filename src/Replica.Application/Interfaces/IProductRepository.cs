using Replica.Shared.Product;

namespace Replica.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto> Create(CreateProductDto entity);
        Task<ProductDto> Delete(Guid id);
        Task<ProductDto> Get(Guid id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<ProductDto> Update(ProductDto entity);
    }
}