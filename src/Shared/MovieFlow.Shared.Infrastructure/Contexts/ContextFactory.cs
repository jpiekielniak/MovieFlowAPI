using Microsoft.AspNetCore.Http;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Shared.Infrastructure.Contexts;

internal class ContextFactory(IHttpContextAccessor httpContextAccessor) : IContextFactory
{
    public IContext Create()
    {
        var httpContext = httpContextAccessor.HttpContext;

        return httpContext is null ? Context.Empty : new Context(httpContext);
    }
}