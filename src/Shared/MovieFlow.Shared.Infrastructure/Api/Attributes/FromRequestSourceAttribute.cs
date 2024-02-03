using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MovieFlow.Shared.Infrastructure.Api.Attributes;

public sealed class FromRequestSourceAttribute : Attribute, IBindingSourceMetadata
{
    public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
        new[] { BindingSource.Path, BindingSource.Query },
        nameof(FromRequestSourceAttribute));
}