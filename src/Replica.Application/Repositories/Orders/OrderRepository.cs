using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Application.Repositories.Base;
using Replica.Domain.Entities.Orders;
using Replica.DTO.Orders.Order;

namespace Replica.Application.Repositories.Orders
{
    public class OrderRepository : RepositoryBase
    {
        public OrderRepository(IReplicaDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }

        public async Task<OrderDTO> Create(OrderDTO entity)
        {
            var order = new Order()
            {
                User = await _dbContext.Users.FindAsync(entity.UserId),
                Table = await _dbContext.Tables.FindAsync(entity.Table.Id),
                GameZone = await _dbContext.GameZones.FindAsync(entity.GameZone.Id),
                Comment = entity.Comment
            };

            foreach (var product in entity.Products)
            {
                order.Products.Add(await _dbContext.Products.FindAsync(product.Id));
            }

            foreach (var hookah in entity.Hookahs)
            {
                order.Hookahs.Add(await _dbContext.Hookahs.FindAsync(hookah.Id));
            }

            await _dbContext.Orders.AddAsync(order);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> Delete(Guid id)
        {
            var order = await _dbContext.Orders.FindAsync(id);

            if(order != null)
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
            var order = await _dbContext.Orders.FindAsync(entity.Id);

            if(order != null)
            {
                order.User = await _dbContext.Users.FindAsync(entity.UserId);
                order.Table = await _dbContext.Tables.FindAsync(entity.Table.Id);
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
