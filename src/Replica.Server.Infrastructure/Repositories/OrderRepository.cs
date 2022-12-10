using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;
using Replica.Shared.Order;

namespace Replica.Server.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderDto> Create(CreateOrderDto entity)
        {
            var order = new Order()
            {
                User = await _dbContext.Users.FindAsync(entity.UserId)
                            ?? throw new NotFoundException(nameof(User), entity.UserId),
                Table = entity.TableId != null ? await _dbContext.Tables.FindAsync(entity.TableId)
                            ?? throw new NotFoundException(nameof(Table), entity.TableId) : null,
                GameZone = entity.GameZoneId != null ? await _dbContext.GameZones.FindAsync(entity.GameZoneId)
                            ?? throw new NotFoundException(nameof(GameZone), entity.GameZoneId) : null,
                Comment = entity.Comment
            };

            if (entity.Products != null)
            {
                foreach (var product in entity.Products)
                {
                    order.Products.Add(await _dbContext.Products.FindAsync(product.Id)
                        ?? throw new NotFoundException(nameof(Product), product.Id));
                }
            }
            if (entity.Hookahs != null)
            {
                foreach (var hookah in entity.Hookahs)
                {
                    order.Hookahs.Add(await _dbContext.Hookahs.FindAsync(hookah.Id)
                        ?? throw new NotFoundException(nameof(Hookah), hookah.Id));
                }
            }

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> Delete(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id)
                ?? throw new NotFoundException(nameof(Order), id);

            _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }

        public async Task<OrderDto> Get(Guid id)
        {
            var orders = await _dbContext.Orders.FindAsync(id)
                ?? throw new NotFoundException(nameof(Order), id);

            return _mapper.Map<OrderDto>(orders);
        }

        public async Task<IEnumerable<OrderDto>> GetAll()
        {
            IEnumerable<Order> orders = await _dbContext.Orders.ToListAsync();

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> GetAllByUser(Guid id)
        {
            IEnumerable<Order> orders = await _dbContext.Orders.Where(x => x.User.Id == id).ToListAsync();

            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> Update(OrderDto entity)
        {
            var order = await _dbContext.Orders.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(User), entity.Id);

            order.User = await _dbContext.Users.FindAsync(entity.UserId)
                        ?? throw new NotFoundException(nameof(User), entity.UserId);
            order.Table = entity.Table != null ? await _dbContext.Tables.FindAsync(entity.Table.Id)
                        ?? throw new NotFoundException(nameof(Table), entity.Table.Id) : null;
            order.GameZone = entity.GameZone != null ? await _dbContext.GameZones.FindAsync(entity.GameZone.Id)
                        ?? throw new NotFoundException(nameof(GameZone), entity.GameZone.Id) : null;
            order.Comment = entity.Comment;

            if (entity.Products != null)
            {
                foreach (var product in entity.Products)
                {
                    order.Products.Add(await _dbContext.Products.FindAsync(product.Id)
                        ?? throw new NotFoundException(nameof(Product), product.Id));
                }
            }

            if (entity.Hookahs != null)
            {
                foreach (var hookah in entity.Hookahs)
                {
                    order.Hookahs.Add(await _dbContext.Hookahs.FindAsync(hookah.Id)
                        ?? throw new NotFoundException(nameof(Hookah), hookah.Id));
                }
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDto>(order);
        }
    }
}
