using AutoMapper;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.DTO.Orders;

namespace Replica.Application.Repository.Orders
{
    public class TableRepository : RepositoryBase
    {
        public TableRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<TableDTO> Create(TableDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TableDTO> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<TableDTO> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TableDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<TableDTO> Update(TableDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
