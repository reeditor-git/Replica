using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Orders.Subcategory;

namespace Replica.Application.Repositories
{
    public class SubcategoryRepository : RepositoryBase
    {
        public SubcategoryRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<SubcategoryDto> Create(CreateSubcategoryDto entity)
        {
            var subcategory = new Subcategory()
            {
                Name = entity.Name,
                Category = await _dbContext.Categories.FindAsync(entity.CategoryId)
                ?? throw new NotFoundException(nameof(Category), entity.CategoryId)
            };

            await _dbContext.Subcategories.AddAsync(subcategory);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        public async Task<SubcategoryDto> Delete(Guid id)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(id)
                ?? throw new NotFoundException(nameof(Subcategory), id);

            _dbContext.Products.RemoveRange(
                await _dbContext.Products
                .Where(x => x.Subcategory.Id == subcategory.Id)
                .ToListAsync());
            _dbContext.Subcategories.Remove(subcategory);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        public async Task<SubcategoryDto> Get(Guid id)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(id);

            return _mapper.Map<SubcategoryDto>(subcategory);
        }

        public async Task<IEnumerable<SubcategoryDto>> GetAll()
        {
            IEnumerable<Subcategory> subcategories = await _dbContext.Subcategories.ToListAsync();

            return _mapper.Map<IEnumerable<SubcategoryDto>>(subcategories);
        }

        public async Task<SubcategoryDto> Update(SubcategoryDto entity)
        {
            var subcategory = await _dbContext.Subcategories.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Subcategory), entity.Id);

            if (subcategory != null)
                subcategory.Name = entity.Name;

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<SubcategoryDto>(subcategory);
        }
    }
}
