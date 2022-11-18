using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Orders.GameZone;

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
                Available = entity.Available,
                SeatingCapacity = entity.SeatingCapacity
            };

            await _dbContext.GameZones.AddAsync(gameZone);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }

        public async Task<GameZoneDTO> Delete(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id);

            if (gameZone != null)
                _dbContext.GameZones.Remove(gameZone);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }

        public async Task<GameZoneDTO> Get(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id);

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
            var gameZone = await _dbContext.GameZones.FindAsync(entity.Id);

            if (gameZone != null)
            {
                gameZone.Name = entity.Name;
                gameZone.Description = entity.Description;
                gameZone.Available = entity.Available;
                gameZone.SeatingCapacity = entity.SeatingCapacity;
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDTO>(gameZone);
        }
    }
}
