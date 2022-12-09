using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Product;

namespace Replica.Application.Repositories
{
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductDto> Create(CreateProductDto entity)
        {
            var product = new Product()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Subcategory = await _dbContext.Subcategories.FindAsync(entity.SubcategoryId)
                    ?? throw new NotFoundException(nameof(Subcategory), entity.SubcategoryId)
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task<ProductDto> Delete(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id)
                ?? throw new NotFoundException(nameof(Product), id);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> Get(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id)
                ?? throw new NotFoundException(nameof(Product), id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            IEnumerable<Product> products = await _dbContext.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> Update(ProductDto entity)
        {
            var product = await _dbContext.Products.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Product), entity.Id);

            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Subcategory = await _dbContext.Subcategories.FindAsync(entity.Subcategory.Id)
                ?? throw new NotFoundException(nameof(Subcategory), entity.Subcategory.Id);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }
    }
}
