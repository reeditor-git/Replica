using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Hookahs;
using Replica.Shared.Hookahs.ComponentCategory;

namespace Replica.Application.Repositories.Hookahs
{
    public class ComponentCategoryRepository : RepositoryBase
    {
        public ComponentCategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ShortComponentCategoryDTO> Create(CreateComponentCategoryDTO entity)
        {
            var componentCategory = new ComponentCategory()
            {
                Name = entity.Name,
                Icon = entity.Icon
            };

            await _dbContext.ComponentCategories.AddAsync(componentCategory);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDTO>(componentCategory);
        }

        public async Task<ShortComponentCategoryDTO> Delete(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id)
                ?? throw new NotFoundException(nameof(ComponentCategory), id);

            _dbContext.HookahComponents.RemoveRange(
                await _dbContext.HookahComponents
                .Where(x => x.Category.Id == componentCategory.Id)
                .ToListAsync());
            _dbContext.ComponentCategories.Remove(componentCategory);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDTO>(componentCategory);
        }

        public async Task<ComponentCategoryDTO> Get(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id)
                ?? throw new NotFoundException(nameof(ComponentCategory), id);

            return _mapper.Map<ComponentCategoryDTO>(componentCategory);
        }

        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll()
        {
            IEnumerable<ComponentCategory>
                componentCategorys = await _dbContext.ComponentCategories.ToListAsync();

            return _mapper.Map<IEnumerable<ComponentCategoryDTO>>(componentCategorys);
        }

        public async Task<IEnumerable<ShortComponentCategoryDTO>> GetAllShort()
        {
            IEnumerable<ComponentCategory>
                componentCategorys = await _dbContext.ComponentCategories.ToListAsync();

            return _mapper.Map<IEnumerable<ShortComponentCategoryDTO>>(componentCategorys);
        }

        public async Task<ShortComponentCategoryDTO> Update(ShortComponentCategoryDTO entity)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(ComponentCategory), entity.Id);

            componentCategory.Name = entity.Name;
            componentCategory.Icon = entity.Icon;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortComponentCategoryDTO>(componentCategory);
        }
    }
}
