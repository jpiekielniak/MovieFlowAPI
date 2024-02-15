using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Shared.Infrastructure.Contexts;

internal interface IContextFactory
{
    IContext Create();
}