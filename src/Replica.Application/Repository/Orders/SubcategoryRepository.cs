using AutoMapper;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.DTO.Orders;

namespace Replica.Application.Repository.Orders
{
    public class SubcategoryRepository : RepositoryBase
    {
        public SubcategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public void Create(SubcategoryDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(SubcategoryDTO entity)
        {
            throw new NotImplementedException();
        }

        public SubcategoryDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubcategoryDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(SubcategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
