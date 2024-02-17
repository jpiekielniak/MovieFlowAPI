using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read;

internal sealed class UserReadConfiguration : IEntityTypeConfiguration<UserReadModel>
{
    public void Configure(EntityTypeBuilder<UserReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Users");
    }
}