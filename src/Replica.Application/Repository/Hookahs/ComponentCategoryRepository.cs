﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.Domain.Entities.Hookahs;
using Replica.DTO.Hookahs.ComponentCategory;
using System.Threading;

namespace Replica.Application.Repository.Hookahs
{
    public class ComponentCategoryRepository : RepositoryBase
    {
        public ComponentCategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ComponentCategoryDTO> Create(ShortComponentCategoryDTO entity)
        {
            var componentCategory = new ComponentCategory()
            {
                Name = entity.Name
            };

            await _dbContext.ComponentCategories.AddAsync(componentCategory);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<ComponentCategoryDTO>(componentCategory);
        }

        public async Task<ComponentCategoryDTO> Delete(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id);
            if (componentCategory != null)
                _dbContext.ComponentCategories.Remove(componentCategory);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ComponentCategoryDTO>(componentCategory);
        }

        public async Task<ComponentCategoryDTO> Get(Guid id)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(id);

            return _mapper.Map<ComponentCategoryDTO>(componentCategory);
        }

        public async Task<IEnumerable<ComponentCategoryDTO>> GetAll()
        {
            IEnumerable<ComponentCategory> 
                componentCategorys = await _dbContext.ComponentCategories.ToListAsync();

            return _mapper.Map<IEnumerable<ComponentCategoryDTO>>(componentCategorys);
        }

        public async Task<ComponentCategoryDTO> Update(ShortComponentCategoryDTO entity)
        {
            var componentCategory = await _dbContext.ComponentCategories.FindAsync(entity.Id);
            
            if(componentCategory != null)
                componentCategory.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ComponentCategoryDTO>(componentCategory);
        }
    }
}