using AutoMapper;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.DTO.Orders;

namespace Replica.Application.Repository.Orders
{
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductDTO> Create(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDTO> Update(ProductDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
