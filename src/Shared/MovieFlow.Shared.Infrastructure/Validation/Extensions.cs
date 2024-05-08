using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace MovieFlow.Shared.Infrastructure.Validation;

public static class Extensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services, Assembly assembly)
    {
        var validatorTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)))
            .ToList();

        foreach (var validatorType in validatorTypes)
        {
            var validatorInterface = validatorType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>));
            services.AddScoped(validatorInterface, validatorType);
        }

        return services;
    }
}