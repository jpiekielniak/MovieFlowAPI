using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Write;
using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Time;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Context;

internal class UsersWriteDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    private readonly IClock _clock;


    public UsersWriteDbContext(DbContextOptions<UsersWriteDbContext> options, IClock clock)
        : base(options)
    {
        _clock = clock;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfiguration(new UserWriteConfiguration());
        modelBuilder.ApplyConfiguration(new RoleWriteConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            if (entry.State == EntityState.Added)
                entry.Property<DateTimeOffset>("CreatedAt").CurrentValue = _clock.CurrentDateTimeOffset();

            if (entry.State is EntityState.Modified or EntityState.Deleted)
                entry.Property<DateTimeOffset>("UpdatedAt").CurrentValue = _clock.CurrentDateTimeOffset();
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}