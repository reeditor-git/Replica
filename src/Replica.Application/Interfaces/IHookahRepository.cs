using Replica.Shared.Hookah;

namespace Replica.Application.Interfaces
{
    public interface IHookahRepository
    {
        Task<HookahDto> Create(CreateHookahDto entity);
        Task<HookahDto> Delete(Guid id);
        Task<HookahDto> Get(Guid id);
        Task<IEnumerable<HookahDto>> GetAll();
        Task<HookahDto> Update(HookahDto entity);
    }
}