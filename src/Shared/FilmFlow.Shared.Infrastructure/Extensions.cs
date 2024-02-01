using FilmFlow.Shared.Abstractions.RenderView;
using FilmFlow.Shared.Abstractions.Time;
using FilmFlow.Shared.Infrastructure.Api;
using FilmFlow.Shared.Infrastructure.Exceptions;
using FilmFlow.Shared.Infrastructure.Postgres;
using FilmFlow.Shared.Infrastructure.RenderView;
using FilmFlow.Shared.Infrastructure.Serialization;
using FilmFlow.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FilmFlow.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {

        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.CustomSchemaIds(x => x.FullName?.Replace("+", ".")); 
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "FilmFLow API",
                Version = "v1"
            });
        });
        
        services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
        services.AddRazorPages();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();
        
        services.AddErrorHandling();
        services.AddPostgres();
        services.AddSingleton<IClock, Clock>();

        services.AddControllers()
            .ConfigureApplicationPartManager(manager =>
            {
                manager.FeatureProviders.Add(new InternalControllerFeatureProvider()); 
            }); 

        return services;
    }
    
    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseCors("cors");
        app.UseErrorHandling();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmFlow.API v1");
            c.DocExpansion(DocExpansion.None);
        });
        
        app.UseRouting();
        app.UseAuthorization();
        
        return app;
    }
    
    public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        return configuration.GetOptions<T>(sectionName);
    }

    public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
    {
        var options = new T();
        configuration.GetSection(sectionName).Bind(options);
        return options;
    }
    
    public static IHostBuilder ConfigureModules(this IHostBuilder builder)
        => builder.ConfigureAppConfiguration((ctx, cfg) =>
        {
            foreach (var settings in GetSettings("*"))
            {
                cfg.AddJsonFile(settings);
            }

            foreach (var settings in
                     GetSettings($"*.{ctx.HostingEnvironment.EnvironmentName}"))
            {
                cfg.AddJsonFile(settings);
            }

            IEnumerable<string> GetSettings(string pattern)
                => Directory.EnumerateFiles(ctx.HostingEnvironment.ContentRootPath,
                    $"module.{pattern}.json", SearchOption.AllDirectories);
        });
    
}