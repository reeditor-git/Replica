using Replica.Application.Interfaces;
using Replica.DTO.Orders;

namespace Replica.Application.Repository.Orders
{
    public class ProductRepository : IRepository<ProductDTO>
    {
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
