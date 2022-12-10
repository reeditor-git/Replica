using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.GameZone;

namespace Replica.Server.Infrastructure.Repositories
{
    public class GameZoneRepository : RepositoryBase, IGameZoneRepository
    {
        public GameZoneRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<GameZoneDto> Create(CreateGameZoneDto entity)
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
            return _mapper.Map<GameZoneDto>(gameZone);
        }

        public async Task<GameZoneDto> Delete(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id)
                ?? throw new NotFoundException(nameof(GameZone), id);

            if (gameZone != null)
                _dbContext.GameZones.Remove(gameZone);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDto>(gameZone);
        }

        public async Task<GameZoneDto> Get(Guid id)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(id)
                ?? throw new NotFoundException(nameof(GameZone), id);

            return _mapper.Map<GameZoneDto>(gameZone);
        }

        public async Task<IEnumerable<GameZoneDto>> GetAll()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones.ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDto>>(gameZones);
        }

        public async Task<IEnumerable<GameZoneDto>> GetAllAvailable()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones
                .Where(x => x.Available == true).ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDto>>(gameZones);
        }

        public async Task<IEnumerable<GameZoneDto>> GetAllUnavailable()
        {
            IEnumerable<GameZone> gameZones = await _dbContext.GameZones
                .Where(x => x.Available == false).ToListAsync();

            return _mapper.Map<IEnumerable<GameZoneDto>>(gameZones);
        }

        public async Task<GameZoneDto> Update(GameZoneDto entity)
        {
            var gameZone = await _dbContext.GameZones.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(GameZone), entity.Id);

            gameZone.Name = entity.Name;
            gameZone.Description = entity.Description;
            gameZone.Available = entity.Available;
            gameZone.SeatingCapacity = entity.SeatingCapacity;
            gameZone.Image = entity.Image;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GameZoneDto>(gameZone);
        }
    }
}
