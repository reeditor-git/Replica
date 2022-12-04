using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.Shared.Orders.GameZone;

namespace Replica.Application.Repositories.Orders
{
    public class GameZoneRepository : RepositoryBase
    {
        public GameZoneRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<GameZoneDTO> Create(CreateGameZoneDTO entity)
        {
            var gameZone = new GameZone()
            {
                Name = entity.Name,
                Description = entity.Description,
                Available = true,
                SeatingCapacity = entity.SeatingCapacity,
                Image = entity.Image
            };

            await _dbContext.GameZones.AddAsync(gameZone);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }

        public async Task<GameZoneDTO> Delete(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id)
                ?? throw new NotFoundException(nameof(GameZone), id);

            if (gameZone != null)
                _dbContext.GameZones.Remove(gameZone);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }

        public async Task<GameZoneDTO> Get(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id)
                ?? throw new NotFoundException(nameof(GameZone), id);

            return _mapper.Map<GameZoneDTO>(gameZone);
        }

        public async Task<IEnumerable<GameZoneDTO>> GetAll()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones.ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDTO>>(gameZones);
        }

        public async Task<IEnumerable<GameZoneDTO>> GetAllAvailable()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones
                .Where(x => x.Available == true).ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDTO>>(gameZones);
        }

        public async Task<IEnumerable<GameZoneDTO>> GetAllUnavailable()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones
                .Where(x => x.Available == false).ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDTO>>(gameZones);
        }

        public async Task<GameZoneDTO> Update(GameZoneDTO entity)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(GameZone), entity.Id);

            gameZone.Name = entity.Name;
            gameZone.Description = entity.Description;
            gameZone.Available = entity.Available;
            gameZone.SeatingCapacity = entity.SeatingCapacity;
            gameZone.Image = entity.Image;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }
    }
}
