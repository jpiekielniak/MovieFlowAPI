using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read;

internal sealed class RoleReadConfiguration : IEntityTypeConfiguration<RoleReadModel>
{
    public void Configure(EntityTypeBuilder<RoleReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Roles");
    }
}