using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscriptionEmailNewsletter;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieFlow.Modules.Newsletters.Api.Endpoints.EmailSubscriptions.Commands.SubscriptionEmailNewsletter;

[Route(EmailSubscriptionEndpoint.Url)]
internal sealed class SubscriptionEmailNewsletterEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<SubscriptionEmailNewsletterCommand>
    .WithoutResult
{
    [AllowAnonymous]
    [HttpPost]
    [SwaggerOperation(
        Summary = "Subscribe to the newsletter",
        Tags = [EmailSubscriptionEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task HandleAsync(SubscriptionEmailNewsletterCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}