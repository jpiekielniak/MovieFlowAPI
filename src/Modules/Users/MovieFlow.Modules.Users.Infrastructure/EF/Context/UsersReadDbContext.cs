using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Context;

internal sealed class UsersReadDbContext : DbContext
{
    public DbSet<UserReadModel> Users { get; set; }
    public DbSet<RoleReadModel> Roles { get; set; }

    public UsersReadDbContext(DbContextOptions<UsersReadDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("users");
        modelBuilder.ApplyConfiguration(new UserReadConfiguration());
        modelBuilder.ApplyConfiguration(new RoleReadConfiguration());
    }
}