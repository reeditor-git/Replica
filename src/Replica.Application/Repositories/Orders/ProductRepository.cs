using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.Domain.Entities.Users;
using Replica.Shared.Orders.Product;

namespace Replica.Application.Repositories.Orders
{
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<ProductDTO> Create(CreateProductDTO entity)
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
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<ProductDTO> Delete(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id)
                ?? throw new NotFoundException(nameof(Product), id);

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Get(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id)
                ?? throw new NotFoundException(nameof(Product), id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            IEnumerable<Product> products = await _dbContext.Products.ToListAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO> Update(ProductDTO entity)
        {
            var product = await _dbContext.Products.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(Product), entity.Id);

            product.Name = entity.Name;
            product.Description = entity.Description;
            product.Price = entity.Price;
            product.Subcategory = await _dbContext.Subcategories.FindAsync(entity.Subcategory.Id)
                ?? throw new NotFoundException(nameof(Subcategory), entity.Subcategory.Id);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
