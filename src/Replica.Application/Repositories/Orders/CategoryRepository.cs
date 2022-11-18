using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Orders.Category;

namespace Replica.Application.Repositories.Orders
{
    public class CategoryRepository : RepositoryBase
    {
        public CategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ShortCategoryDTO> Create(CreateCategoryDTO entity)
        {
            var category = new Category()
            {
                Name = entity.Name
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDTO>(entity);
        }

        public async Task<ShortCategoryDTO> Delete(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id);

            if(category != null)
                _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDTO>(category);
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

        public async Task<IEnumerable<ShortCategoryDTO>> GetAllShort()
        {
            IEnumerable<Category> categories = await _dbContext.Categories.ToListAsync();

            return _mapper.Map<IEnumerable<ShortCategoryDTO>>(categories);
        }

        public async Task<ShortCategoryDTO> Update(ShortCategoryDTO entity)
        {
            var category = await _dbContext.Categories.FindAsync(entity.Id);
            if (category != null)
                category.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDTO>(category);
        }
    }
}
