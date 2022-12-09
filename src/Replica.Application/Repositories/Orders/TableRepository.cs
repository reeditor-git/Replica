using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.Shared.Orders.Table;

namespace Replica.Application.Repositories.Orders
{
    public class TableRepository : RepositoryBase
    {
        public TableRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<TableDTO> Create(CreateTableDTO entity)
        {
            var table = new Table()
            {
                TableNumber = entity.TableNumber,
                Description = entity.Description,
                Available = entity.Available,
                SeatingCapacity = entity.SeatingCapacity
            };

            await _dbContext.Tables.AddAsync(table);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TableDTO>(table);
        }

        public async Task<TableDTO> Delete(Guid id)
        {
            var table = await _dbContext.Tables.FindAsync(id)
                ?? throw new NotFoundException(nameof(Table), id);

            _dbContext.Tables.Remove(table);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TableDTO>(table);
        }

        public async Task<TableDTO> Get(Guid id)
        {
            var table = await _dbContext.Tables.FindAsync(id)
                ?? throw new NotFoundException(nameof(Table), id);

            return _mapper.Map<TableDTO>(table);
        }

        public async Task<IEnumerable<TableDTO>> GetAll()
        {
            IEnumerable<Table> tables = await _dbContext.Tables.ToListAsync();

            return _mapper.Map<IEnumerable<TableDTO>>(tables);
        }

        public async Task<IEnumerable<TableDTO>> GetAllAvailable()
        {
            IEnumerable<Table> tables = await _dbContext.Tables
                .Where(x => x.Available == true).ToListAsync();

            return _mapper.Map<IEnumerable<TableDTO>>(tables);
        }

        public async Task<IEnumerable<TableDTO>> GetAllUnavailable()
        {
            IEnumerable<Table> tables = await _dbContext.Tables
                .Where(x => x.Available == false).ToListAsync();

            return _mapper.Map<IEnumerable<TableDTO>>(tables);
        }

        public async Task<TableDTO> Update(TableDTO entity)
        {
            var table = await _dbContext.Tables.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Subcategory), entity.Id);

            table.TableNumber = entity.TableNumber;
            table.Description = entity.Description;
            table.Available = entity.Available;
            table.SeatingCapacity = entity.SeatingCapacity;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TableDTO>(table);
        }
    }
}
