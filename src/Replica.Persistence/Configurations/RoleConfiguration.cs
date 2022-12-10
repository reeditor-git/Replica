using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Replica.Domain.Entities;

namespace Replica.Persistence.Configurations
{
    class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(64);

            builder.HasMany(r => r.Users)
                .WithOne(r => r.Role);

            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("6fa17fba-626d-481c-81cd-bbda29109fab"),
                    Name = "admin",
                    Description = "Admin"
                },
                new Role
                {
                    Id = Guid.Parse("2bb5984d-3ff9-49c3-9e54-5dcff385fb98"),
                    Name = "manager",
                    Description = "Manager"
                }
                );
        }
    }
}
