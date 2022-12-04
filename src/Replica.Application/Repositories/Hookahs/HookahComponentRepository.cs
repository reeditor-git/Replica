﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Hookahs;
using Replica.Shared.Hookahs.HookahComponent;

namespace Replica.Application.Repositories.Hookahs
{
    public class HookahComponentRepository : RepositoryBase
    {
        public HookahComponentRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<HookahComponentDTO> Create(CreateHookahComponentDTO entity)
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

            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }

        public async Task<HookahComponentDTO> Delete(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id)
                ?? throw new NotFoundException(nameof(HookahComponent), id);

            _dbContext.HookahComponents.Remove(hookahComponent);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }

        public async Task<HookahComponentDTO> Get(Guid id)
        {
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(id)
                ?? throw new NotFoundException(nameof(HookahComponent), id);

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
            var hookahComponent = await _dbContext.HookahComponents.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(HookahComponent), entity.Id);

            hookahComponent.Name = entity.Name;
            hookahComponent.Price = entity.Price;
            hookahComponent.Description = entity.Description;
            hookahComponent.Image = entity.Image;
            hookahComponent.Category = await _dbContext.ComponentCategories.FindAsync(entity.Category.Id)
                ?? throw new NotFoundException(nameof(ComponentCategory), entity.Category.Id);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<HookahComponentDTO>(hookahComponent);
        }
    }
}