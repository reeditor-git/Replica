using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Exceptions;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.Domain.Entities.Users;
using Replica.Shared.Orders.Order;

namespace Replica.Application.Repositories.Orders
{
    public class OrderRepository : RepositoryBase
    {
        public OrderRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderDTO> Create(CreateOrderDTO entity)
        {
            var order = new Order()
            {
                User = await _dbContext.Users.FindAsync(entity.UserId)
                            ?? throw new NotFoundException(nameof(User), entity.UserId),
                Table = entity.TableId != null ? await _dbContext.Tables.FindAsync(entity.TableId)
                            ?? throw new NotFoundException(nameof(User), entity.TableId) : null,
                GameZone = entity.GameZoneId != null ? await _dbContext.GameZones.FindAsync(entity.GameZoneId)
                            ?? throw new NotFoundException(nameof(User), entity.GameZoneId) : null,
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
                    order.Hookahs.Add(await _dbContext.Hookahs.FindAsync(hookah.Id));
                }
            }

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> Delete(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if (order != null)
                _dbContext.Orders.Remove(order);

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> Get(Guid id)
        {
            var orders = await _dbContext.Orders.FindAsync(id);

            return _mapper.Map<OrderDTO>(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetAll()
        {
            IEnumerable<Order> orders = await _dbContext.Orders.ToListAsync();

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> Update(OrderDTO entity)
        {
            var order = await _dbContext.Orders.FindAsync(entity.Id)
                ?? throw new NotFoundException(nameof(User), entity.Id);

            if (order != null)
            {
                order.User = await _dbContext.Users.FindAsync(entity.UserId)
                            ?? throw new NotFoundException(nameof(User), entity.UserId);
                order.Table = entity.Table.Id != null ? await _dbContext.Tables.FindAsync(entity.Table.Id)
                            ?? throw new NotFoundException(nameof(User), entity.Table.Id) : null;
                order.GameZone = await _dbContext.GameZones.FindAsync(entity.GameZone.Id);
                order.Comment = entity.Comment;
            }
            foreach (var product in entity.Products)
            {
                order.Products.Add(await _dbContext.Products.FindAsync(product.Id));
            }

            foreach (var hookah in entity.Hookahs)
            {
                order.Hookahs.Add(await _dbContext.Hookahs.FindAsync(hookah.Id));
            }

            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }
    }
}
