using System.Reflection;
using System.Runtime.CompilerServices;
using MovieFlow.Shared.Abstractions.RenderView;
using MovieFlow.Shared.Abstractions.Time;
using MovieFlow.Shared.Infrastructure.Api;
using MovieFlow.Shared.Infrastructure.Exceptions;
using MovieFlow.Shared.Infrastructure.Postgres;
using MovieFlow.Shared.Infrastructure.RenderView;
using MovieFlow.Shared.Infrastructure.Serialization;
using MovieFlow.Shared.Infrastructure.Time;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MovieFlow.Shared.Abstractions.Modules;
using MovieFlow.Shared.Infrastructure.Auth;
using MovieFlow.Shared.Infrastructure.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

[assembly: InternalsVisibleTo("MovieFlow.Bootstrapper")]

namespace MovieFlow.Shared.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInitializer<T>(this IServiceCollection services)
        where T : class, IInitializer
        => services.AddTransient<IInitializer, T>();

    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IList<Assembly> assemblies, IList<IModule> modules)
    {
        services.AddSwaggerGen(swagger =>
        {
            swagger.EnableAnnotations();
            swagger.CustomSchemaIds(x => x.FullName?.Replace("+", "."));
            swagger.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MovieFlow API",
                Version = "v1"
            });

            swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });

            swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        services.AddScoped<IRazorViewRenderer, RazorViewRenderer>();
        services.AddRazorPages();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IJsonSerializer, SystemTextJsonSerializer>();
        services.AddAuth(modules);
        services.AddErrorHandling();
        services.AddPostgres();
        services.AddSingleton<IClock, Clock>();
        services.AddHostedService<AppInitializer>();
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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieFlow.API v1");
            c.DocExpansion(DocExpansion.None);
        });

        app.UseAuthentication();
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

    public static string GetModuleName(this Type type)
    {
        if (type?.Namespace is null)
            return string.Empty;

        return type.Namespace.StartsWith("MovieFlow.Modules.")
            ? type.Namespace.Split(".")[2].ToLowerInvariant()
            : string.Empty;
    }
}