using Replica.Shared.HookahComponent;

namespace Replica.Application.Interfaces
{
    public interface IHookahComponentRepository
    {
        Task<HookahComponentDto> Create(CreateHookahComponentDto entity);
        Task<HookahComponentDto> Delete(Guid id);
        Task<HookahComponentDto> Get(Guid id);
        Task<IEnumerable<HookahComponentDto>> GetAll();
        Task<HookahComponentDto> Update(HookahComponentDto entity);
    }
}