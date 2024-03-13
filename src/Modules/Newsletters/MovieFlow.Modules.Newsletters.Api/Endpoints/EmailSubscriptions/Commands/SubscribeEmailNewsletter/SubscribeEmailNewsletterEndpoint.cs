using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscribeEmailNewsletter;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieFlow.Modules.Newsletters.Api.Endpoints.EmailSubscriptions.Commands.SubscribeEmailNewsletter;

[Route(EmailSubscriptionEndpoint.Url)]
internal sealed class SubscribeEmailNewsletterEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<SubscribeEmailNewsletterCommand>
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
    public override async Task HandleAsync(SubscribeEmailNewsletterCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}