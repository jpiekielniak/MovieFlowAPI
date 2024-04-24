using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

internal sealed class CreateActorHandler(
    IActorRepository actorRepository,
    IAzureStorageService azureStorageService)
    : IRequestHandler<CreateActorCommand, CreateActorResponse>
{
    public async Task<CreateActorResponse> Handle(CreateActorCommand command,
        CancellationToken cancellationToken)
    {
        var actor = Actor.Create(
            command.FirstName,
            command.LastName,
            command.DateOfBirth,
            command.Country);

        await azureStorageService.UploadImageAsync(command.Photo);
        var photoUrl = await azureStorageService.GetImageUrlAsync(command.Photo.FileName);

        var photo = Photo.Create(
            command.Photo.FileName,
            photoUrl,
            $"{command.FirstName} {command.LastName}",
            command.Photo.ContentType
        );

        actor.AddPhoto(photo);
        await actorRepository.AddAsync(actor, cancellationToken);

        return new CreateActorResponse(actor.Id);
    }
}