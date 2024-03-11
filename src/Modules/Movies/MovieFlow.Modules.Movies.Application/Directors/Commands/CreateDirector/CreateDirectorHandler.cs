using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;

internal sealed class CreateDirectorHandler(
    IDirectorRepository directorRepository,
    IAzureStorageService azureStorageService)
    : IRequestHandler<CreateDirectorCommand, CreateDirectorResponse>
{
    public async Task<CreateDirectorResponse> Handle(CreateDirectorCommand command,
        CancellationToken cancellationToken)
    {
        var director = Director.Create(
            command.FirstName,
            command.LastName,
            command.DateOfBirth,
            command.Country
        );

        await azureStorageService.UploadImageAsync(command.Photo);
        var photoUrl = await azureStorageService.GetImageUrlAsync(command.Photo.FileName);

        var photo = Photo.Create(
            command.Photo.FileName,
            photoUrl,
            $"{command.FirstName} {command.LastName}",
            command.Photo.ContentType
        );
        
        director.AddPhoto(DirectorPhoto.Create(director, photo));

        await directorRepository.AddAsync(director, cancellationToken);
        return new CreateDirectorResponse(director.Id);
    }
}