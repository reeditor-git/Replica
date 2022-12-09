using Microsoft.EntityFrameworkCore;
using Replica.Application.Interfaces;
using Replica.Domain.Entities;

namespace Replica.Persistence
{
    public class ReplicaDbContext : DbContext, IReplicaDbContext
    {
        public ReplicaDbContext(DbContextOptions<ReplicaDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<GameZone> GameZones { get; set; }

        public DbSet<Hookah> Hookahs { get; set; }
        public DbSet<HookahComponent> HookahComponents { get; set; }
        public DbSet<ComponentCategory> ComponentCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ReplicaDbContext).Assembly);
        }
    }
}