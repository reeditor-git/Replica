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

        public void Create(TableDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TableDTO entity)
        {
            throw new NotImplementedException();
        }

        public TableDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TableDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TableDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
