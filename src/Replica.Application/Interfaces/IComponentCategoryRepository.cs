using Replica.Shared.ComponentCategory;

namespace Replica.Application.Interfaces
{
    public interface IComponentCategoryRepository
    {
        Task<ShortComponentCategoryDto> Create(CreateComponentCategoryDto entity);
        Task<ShortComponentCategoryDto> Delete(Guid id);
        Task<ComponentCategoryDto> Get(Guid id);
        Task<IEnumerable<ComponentCategoryDto>> GetAll();
        Task<IEnumerable<ShortComponentCategoryDto>> GetAllShort();
        Task<ShortComponentCategoryDto> Update(ShortComponentCategoryDto entity);
    }
}