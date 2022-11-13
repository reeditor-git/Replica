using AutoMapper;
using Replica.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replica.Application.Repository.Base
{
    public abstract class RepositoryBase
    {
        protected readonly IReplicaDbContext _dbContext;
        protected readonly IMapper _mapper;

        protected RepositoryBase(IReplicaDbContext dbContext, IMapper mapper) =>
              (_dbContext, _mapper) = (dbContext, mapper);
    }
}
