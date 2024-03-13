using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieFlow.Modules.Newsletters.Api.Endpoints.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;

[Route(EmailSubscriptionEndpoint.Url)]
internal sealed class UnSubscribeEmailNewsletterEndpoint(IMediator mediator) : EndpointBaseAsync
    .WithRequest<UnSubscribeEmailNewsletterCommand>
    .WithoutResult
{
    [AllowAnonymous]
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Un subscribe to the newsletter",
        Tags = [EmailSubscriptionEndpoint.Tag]
    )]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorsResponse))]
    public override async Task HandleAsync(UnSubscribeEmailNewsletterCommand command,
        CancellationToken cancellationToken = default)
        => await mediator.Send(command, cancellationToken);
}
