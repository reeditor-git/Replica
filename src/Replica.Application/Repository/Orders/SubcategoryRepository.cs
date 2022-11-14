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

        public async Task<SubcategoryDTO> Create(SubcategoryDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SubcategoryDTO> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<SubcategoryDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubcategoryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<SubcategoryDTO> Update(SubcategoryDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
