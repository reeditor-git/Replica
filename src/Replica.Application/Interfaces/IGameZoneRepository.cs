using Replica.Shared.GameZone;

namespace Replica.Application.Interfaces
{
    public interface IGameZoneRepository
    {
        Task<GameZoneDto> Create(CreateGameZoneDto entity);
        Task<GameZoneDto> Delete(Guid id);
        Task<GameZoneDto> Get(Guid id);
        Task<IEnumerable<GameZoneDto>> GetAll();
        Task<IEnumerable<GameZoneDto>> GetAllAvailable();
        Task<IEnumerable<GameZoneDto>> GetAllUnavailable();
        Task<GameZoneDto> Update(GameZoneDto entity);
    }
}