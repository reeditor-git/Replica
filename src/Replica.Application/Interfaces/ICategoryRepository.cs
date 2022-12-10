using Replica.Shared.Category;

namespace Replica.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ShortCategoryDto> Create(CreateCategoryDto entity);
        Task<ShortCategoryDto> Delete(Guid id);
        Task<CategoryDto> Get(Guid id);
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<IEnumerable<ShortCategoryDto>> GetAllShort();
        Task<ShortCategoryDto> Update(ShortCategoryDto entity);
    }
}