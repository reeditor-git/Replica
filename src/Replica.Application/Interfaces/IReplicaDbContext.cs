using Microsoft.EntityFrameworkCore;
using Replica.Domain.Entities;

namespace Replica.Application.Interfaces
{
    public interface IReplicaDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RefreshToken> RefreshTokens { get; set; }

        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        DbSet<Table> Tables { get; set; }
        DbSet<GameZone> GameZones { get; set; }

        DbSet<Hookah> Hookahs { get; set; }
        DbSet<HookahComponent> HookahComponents { get; set; }
        DbSet<ComponentCategory> ComponentCategories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
