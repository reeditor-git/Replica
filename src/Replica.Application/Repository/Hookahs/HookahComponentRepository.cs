using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.Domain.Entities.Hookahs;
using Replica.DTO.Hookahs.HookahComponent;

namespace Replica.Application.Repository.Hookahs
{
    public class HookahComponentRepository : RepositoryBase
    {
        public HookahComponentRepository(IReplicaDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper) { }

        public async Task<HookahComponentDTO> Create(HookahComponentDTO entity)
        {
            var hookahComponent = new HookahComponent()
            {
                Name = entity.Name,
                Price = entity.Price,
                Category = await _dbContext.ComponentCategories.FindAsync(entity.Category.Id)
            };

            await _dbContext.HookahComponents.AddAsync(hookahComponent);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }

        public async Task<HookahComponentDTO> Delete(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id);
            
            if (hookahComponent != null)
                _dbContext.HookahComponents.Remove(hookahComponent);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }

        public async Task<HookahComponentDTO> Get(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id);

            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }

        public async Task<IEnumerable<HookahComponentDTO>> GetAll()
        {
            IEnumerable<HookahComponent>
                hookahComponent = await _dbContext.HookahComponents.ToListAsync();

            return _mapper.Map<IEnumerable<HookahComponentDTO>>(hookahComponent);
        }

        public async Task<HookahComponentDTO> Update(HookahComponentDTO entity)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(entity.Id);

            if (hookahComponent != null)
            {
                hookahComponent.Name = entity.Name;
                hookahComponent.Price = entity.Price;
                hookahComponent.Category = await _dbContext.ComponentCategories.FindAsync(entity.Category.Id);
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }
    }
}
