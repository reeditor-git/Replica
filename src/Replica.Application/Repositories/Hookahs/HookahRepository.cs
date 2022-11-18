using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Hookahs;
using Replica.DTO.Hookahs.Hookah;

namespace Replica.Application.Repositories.Hookahs
{
    public class HookahRepository : RepositoryBase
    {
        public HookahRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<HookahDTO> Create(CreateHookahDTO entity)
        {
            var hookah = new Hookah()
            {
                AdditionalHose = entity.AdditionalHose
            };

            foreach (var component in entity.Components)
            {
                hookah.Components.Add(await _dbContext.HookahComponents.FindAsync(component.Id));
            }

            await _dbContext.Hookahs.AddAsync(hookah);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDTO>(hookah);
        }

        public async Task<HookahDTO> Delete(Guid id)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(id);

            if (hookah != null)
            {
                hookah.Components.Clear();
                _dbContext.Hookahs.Remove(hookah);
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDTO>(hookah);
        }

        public async Task<HookahDTO> Get(Guid id)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(id);

            return _mapper.Map<HookahDTO>(hookah);
        }

        public async Task<IEnumerable<HookahDTO>> GetAll()
        {
            IEnumerable<Hookah>
                hookah = await _dbContext.Hookahs.ToListAsync();

            return _mapper.Map<IEnumerable<HookahDTO>>(hookah);
        }

        public async Task<HookahDTO> Update(HookahDTO entity)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(entity.Id);

            if (hookah != null)
            {
                hookah.AdditionalHose = entity.AdditionalHose;
                hookah.Components.Clear();
            }
            foreach (var component in entity.Components)
            {
                hookah.Components.Add(await _dbContext.HookahComponents.FindAsync(component.Id));
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDTO>(hookah);
        }
    }
}
