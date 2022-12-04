using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Application.Repositories.Orders
{
    public class SubcategoryRepository : RepositoryBase
    {
        public SubcategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SubcategoryDTO> Create(SubcategoryDTO entity)
        {
            var subcategory = new Subcategory()
            {
                Name = entity.Name,
                Category = await _dbContext.Categories.FindAsync(entity.Category.Id)
            };

            await _dbContext.Subcategories.AddAsync(subcategory);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDTO>(subcategory);
        }

        public async Task<SubcategoryDTO> Delete(Guid id)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(id);

            if (subcategory != null)
                _dbContext.Subcategories.Remove(subcategory);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDTO>(subcategory);
        }

        public async Task<SubcategoryDTO> Get(Guid id)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(id);

            return _mapper.Map<SubcategoryDTO>(subcategory);
        }

        public async Task<IEnumerable<SubcategoryDTO>> GetAll()
        {
            IEnumerable<Subcategory> subcategories = await _dbContext.Subcategories.ToListAsync();

            return _mapper.Map<IEnumerable<SubcategoryDTO>>(subcategories);
        }

        public async Task<SubcategoryDTO> Update(SubcategoryDTO entity)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(entity.Id);

            if (subcategory != null)
                subcategory.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDTO>(subcategory);
        }
    }
}
