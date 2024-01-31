using FilmFlow.Shared.Infrastructure.Postgres.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FilmFlow.Shared.Infrastructure.Postgres;

public static partial class Extensions
{
    public static Task<Paged<TDestination>> PaginateAsync<TDestination>(
        this IQueryable<TDestination> queryable, PaginationRequest req, CancellationToken cancellationToken = default)
    {
        return Paged<TDestination>.CreateAsync(queryable, req.PageNumber, req.PageSize, cancellationToken);
    }

    internal static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        //w tym przypadku nie mozna zmieniac dynamicznie appsetingosow np co 30 mi przy ochrnie aplikacji 
        var options = services.GetOptions<PostgresOptions>("postgres");
        services.AddSingleton(options);

        // Temporary fix for EF Core issue related to https://github.com/npgsql/efcore.pg/issues/2000
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


        return services;
    }

    public static IServiceCollection AddPostgres<T>(this IServiceCollection services) where T : DbContext
    {
        var options = services.GetOptions<PostgresOptions>("postgres");

        services.AddDbContext<T>(x => x.UseNpgsql(options.ConnectionString));

        //todo use NetTopology
        // services.AddDbContext<T>(x =>
        // x.UseNpgsql(options.ConnectionString, o => o.UseNetTopologySuite()));

        return services;
    }

    // public static IServiceCollection AddSqlServer<T>(this IServiceCollection services, connectionString) where T : DbContext
    // {
    //     var connectionString = "";
    //
    //     services.AddDbContext<T>(x => x.UseSqlServer(connectionString)); // Używamy UseSqlServer() do ustawienia połączenia z MSSQL
    //
    //     return services;
    // }

}