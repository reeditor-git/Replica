using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repository.Base;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Orders.Category;

namespace Replica.Application.Repository.Orders
{
    public class CategoryRepository : RepositoryBase
    {
        public CategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<CategoryDTO> Create(CategoryDTO entity)
        {
            var category = new Category()
            {
                Name = entity.Name
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task<CategoryDTO> Delete(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            if(category != null)
                _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> Get(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            IEnumerable<Category> categories = await _dbContext.Categories.ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> Update(CategoryDTO entity)
        {
            var category = await _dbContext.Categories.FindAsync(entity.Id);
            if (category != null)
                category.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}
