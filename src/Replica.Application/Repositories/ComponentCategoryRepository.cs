using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.ComponentCategory;

namespace Replica.Application.Repositories
{
    public class ComponentCategoryRepository : RepositoryBase
    {
        public ComponentCategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ShortComponentCategoryDto> Create(CreateComponentCategoryDto entity)
        {
            var componentCategory = new ComponentCategory()
            {
                Name = entity.Name,
                Icon = entity.Icon
            };

            await _dbContext.ComponentCategories.AddAsync(componentCategory);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDto>(componentCategory);
        }

        public async Task<ShortComponentCategoryDto> Delete(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id)
                ?? throw new NotFoundException(nameof(ComponentCategory), id);

            _dbContext.HookahComponents.RemoveRange(
                await _dbContext.HookahComponents
                .Where(x => x.Category.Id == componentCategory.Id)
                .ToListAsync());
            _dbContext.ComponentCategories.Remove(componentCategory);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDto>(componentCategory);
        }

        public async Task<ComponentCategoryDto> Get(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id)
                ?? throw new NotFoundException(nameof(ComponentCategory), id);

            return _mapper.Map<ComponentCategoryDto>(componentCategory);
        }

        public async Task<IEnumerable<ComponentCategoryDto>> GetAll()
        {
            IEnumerable<ComponentCategory>
                componentCategorys = await _dbContext.ComponentCategories.ToListAsync();

            return _mapper.Map<IEnumerable<ComponentCategoryDto>>(componentCategorys);
        }

        public async Task<IEnumerable<ShortComponentCategoryDto>> GetAllShort()
        {
            IEnumerable<ComponentCategory>
                componentCategorys = await _dbContext.ComponentCategories.ToListAsync();

            return _mapper.Map<IEnumerable<ShortComponentCategoryDto>>(componentCategorys);
        }

        public async Task<ShortComponentCategoryDto> Update(ShortComponentCategoryDto entity)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(ComponentCategory), entity.Id);

            componentCategory.Name = entity.Name;
            componentCategory.Icon = entity.Icon;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDto>(componentCategory);
        }
    }
}
