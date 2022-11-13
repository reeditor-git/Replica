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

        public void Create(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductDTO entity)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ProductDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
