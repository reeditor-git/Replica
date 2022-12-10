using Replica.Shared.Subcategory;

namespace Replica.Application.Interfaces
{
    public interface ISubcategoryRepository
    {
        Task<SubcategoryDto> Create(CreateSubcategoryDto entity);
        Task<SubcategoryDto> Delete(Guid id);
        Task<SubcategoryDto> Get(Guid id);
        Task<IEnumerable<SubcategoryDto>> GetAll();
        Task<SubcategoryDto> Update(SubcategoryDto entity);
    }
}