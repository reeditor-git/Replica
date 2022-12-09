using AutoMapper;
using Replica.Application.Interfaces;

namespace Replica.Application.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IReplicaDbContext _dbContext;
        protected readonly IMapper _mapper;

        protected RepositoryBase(IReplicaDbContext dbContext, IMapper mapper) =>
              (_dbContext, _mapper) = (dbContext, mapper);
    }
}
