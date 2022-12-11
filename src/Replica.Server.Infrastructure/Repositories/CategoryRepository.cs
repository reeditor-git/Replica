using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Category;

namespace Replica.Server.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase, ICategoryRepository
    {
        public CategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ShortCategoryDto> Create(CreateCategoryDto entity)
        {
            var category = new Category()
            {
                Name = entity.Name,
                Description = entity.Description,
                Icon = entity.Icon
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDto>(entity);
        }

        public async Task<ShortCategoryDto> Delete(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id)
                ?? throw new NotFoundException(nameof(Category), id);
            var subcategory = await _dbContext.Subcategories.Where(x => x.Category.Id == category.Id).ToListAsync();
            var product = new List<Product>();

            foreach (var sub in subcategory)
            {
                product = await _dbContext.Products.Where(x => x.Subcategory.Id == sub.Id).ToListAsync();
            }

            _dbContext.Products.RemoveRange(product);
            _dbContext.Subcategories.RemoveRange(subcategory);
            _dbContext.Categories.Remove(category);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDto>(category);
        }

        public async Task<CategoryDto> Get(Guid id)
        {
            var category = await _dbContext.Categories.FindAsync(id)
                ?? throw new NotFoundException(nameof(Category), id);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            IEnumerable<Category> categories = await _dbContext.Categories.ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<IEnumerable<ShortCategoryDto>> GetAllShort()
        {
            IEnumerable<Category> categories = await _dbContext.Categories.ToListAsync();

            return _mapper.Map<IEnumerable<ShortCategoryDto>>(categories);
        }

        public async Task<ShortCategoryDto> Update(ShortCategoryDto entity)
        {
            var category = await _dbContext.Categories.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Category), entity.Id);

            category.Name = entity.Name;
            category.Icon = entity.Icon;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ShortCategoryDto>(category);
        }
    }
}
