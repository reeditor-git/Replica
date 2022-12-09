using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Table;

namespace Replica.Application.Repositories
{
    public class TableRepository : RepositoryBase
    {
        public TableRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<TableDto> Create(CreateTableDto entity)
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
            return _mapper.Map<TableDto>(table);
        }

        public async Task<TableDto> Delete(Guid id)
        {
            var table = await _dbContext.Tables.FindAsync(id)
                ?? throw new NotFoundException(nameof(Table), id);

            _dbContext.Tables.Remove(table);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TableDto>(table);
        }

        public async Task<TableDto> Get(Guid id)
        {
            var table = await _dbContext.Tables.FindAsync(id)
                ?? throw new NotFoundException(nameof(Table), id);

            return _mapper.Map<TableDto>(table);
        }

        public async Task<IEnumerable<TableDto>> GetAll()
        {
            IEnumerable<Table> tables = await _dbContext.Tables.ToListAsync();

            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<IEnumerable<TableDto>> GetAllAvailable()
        {
            IEnumerable<Table> tables = await _dbContext.Tables
                .Where(x => x.Available == true).ToListAsync();

            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<IEnumerable<TableDto>> GetAllUnavailable()
        {
            IEnumerable<Table> tables = await _dbContext.Tables
                .Where(x => x.Available == false).ToListAsync();

            return _mapper.Map<IEnumerable<TableDto>>(tables);
        }

        public async Task<TableDto> Update(TableDto entity)
        {
            var table = await _dbContext.Tables.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Subcategory), entity.Id);

            table.TableNumber = entity.TableNumber;
            table.Description = entity.Description;
            table.Available = entity.Available;
            table.SeatingCapacity = entity.SeatingCapacity;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<TableDto>(table);
        }
    }
}
