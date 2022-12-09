using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.HookahComponent;

namespace Replica.Application.Repositories
{
    public class HookahComponentRepository : RepositoryBase
    {
        public HookahComponentRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<HookahComponentDto> Create(CreateHookahComponentDto entity)
        {
            var hookahComponent = new HookahComponent()
            {
                Name = entity.Name,
                Price = entity.Price,
                Description = entity.Description,
                Image = entity.Image,
                Category = await _dbContext.ComponentCategories.FindAsync(entity.CategoryId)
                ?? throw new NotFoundException(nameof(ComponentCategory), entity.CategoryId)
            };

            await _dbContext.HookahComponents.AddAsync(hookahComponent);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<HookahComponentDto>(hookahComponent);
        }

        public async Task<HookahComponentDto> Delete(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id)
                ?? throw new NotFoundException(nameof(HookahComponent), id);

            _dbContext.HookahComponents.Remove(hookahComponent);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDto>(hookahComponent);
        }

        public async Task<HookahComponentDto> Get(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id)
                ?? throw new NotFoundException(nameof(HookahComponent), id);

            return _mapper.Map<HookahComponentDto>(hookahComponent);
        }

        public async Task<IEnumerable<HookahComponentDto>> GetAll()
        {
            IEnumerable<HookahComponent>
                hookahComponent = await _dbContext.HookahComponents.ToListAsync();

            return _mapper.Map<IEnumerable<HookahComponentDto>>(hookahComponent);
        }

        public async Task<HookahComponentDto> Update(HookahComponentDto entity)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(HookahComponent), entity.Id);

            hookahComponent.Name = entity.Name;
            hookahComponent.Price = entity.Price;
            hookahComponent.Description = entity.Description;
            hookahComponent.Image = entity.Image;
            hookahComponent.Category = await _dbContext.ComponentCategories.FindAsync(entity.Category.Id)
                ?? throw new NotFoundException(nameof(ComponentCategory), entity.Category.Id);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDto>(hookahComponent);
        }
    }
}
