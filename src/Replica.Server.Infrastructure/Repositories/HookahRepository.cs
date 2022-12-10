using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Hookah;

namespace Replica.Server.Infrastructure.Repositories
{
    public class HookahRepository : RepositoryBase, IHookahRepository
    {
        public HookahRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<HookahDto> Create(CreateHookahDto entity)
        {
            var hookah = new Hookah()
            {
                AdditionalHose = entity.AdditionalHose,
                Image = entity.Image
            };

            foreach (var component in entity.Components)
            {
                hookah.Components.Add(await _dbContext.HookahComponents.FindAsync(component.Id)
                    ?? throw new NotFoundException(nameof(HookahComponent), component.Id));
            }

            await _dbContext.Hookahs.AddAsync(hookah);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDto>(hookah);
        }

        public async Task<HookahDto> Delete(Guid id)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(id)
                ?? throw new NotFoundException(nameof(Hookah), id);

            if (hookah != null)
            {
                hookah.Components.Clear();
                _dbContext.Hookahs.Remove(hookah);
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDto>(hookah);
        }

        public async Task<HookahDto> Get(Guid id)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(id)
                ?? throw new NotFoundException(nameof(Hookah), id);

            return _mapper.Map<HookahDto>(hookah);
        }

        public async Task<IEnumerable<HookahDto>> GetAll()
        {
            IEnumerable<Hookah>
                hookah = await _dbContext.Hookahs.ToListAsync();

            return _mapper.Map<IEnumerable<HookahDto>>(hookah);
        }

        public async Task<HookahDto> Update(HookahDto entity)
        {
            var hookah = await _dbContext.Hookahs.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Hookah), entity.Id);

            hookah.AdditionalHose = entity.AdditionalHose;
            hookah.Image = entity.Image;
            hookah.Components.Clear();

            foreach (var component in entity.Components)
            {
                hookah.Components.Add(await _dbContext.HookahComponents.FindAsync(component.Id)
                    ?? throw new NotFoundException(nameof(HookahComponent), component.Id));
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahDto>(hookah);
        }
    }
}
