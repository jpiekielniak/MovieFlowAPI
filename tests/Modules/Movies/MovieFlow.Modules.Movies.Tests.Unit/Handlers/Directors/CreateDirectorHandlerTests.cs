using MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;
using MovieFlow.Modules.Movies.AzureStorage.Services;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Directors;

public class CreateDirectorHandlerTests
{
    private async Task<CreateDirectorResponse> Act(CreateDirectorCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_director_should_succeed()
    {
        //Arrange
        var command = CreateDirectorCommand();
        _azureStorageService.UploadImageAsync(Arg.Any<IFormFile>())
            .Returns(Task.CompletedTask);
        _azureStorageService.GetImageUrlAsync(Arg.Any<string>())
            .Returns(string.Empty);
        _directorRepository.AddAsync(Arg.Any<Director>(), Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        var result = await Act(command);
        
        //Assert
        result.ShouldNotBeNull();
        result.ShouldNotBeSameAs(Guid.Empty);
        await _azureStorageService.Received(1).UploadImageAsync(Arg.Any<IFormFile>());
        await _azureStorageService.Received(1).GetImageUrlAsync(Arg.Any<string>());
        await _directorRepository.Received(1).AddAsync(Arg.Any<Director>(), Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<CreateDirectorCommand, CreateDirectorResponse> _handler;
    private readonly IDirectorRepository _directorRepository;
    private readonly IAzureStorageService _azureStorageService;

    public CreateDirectorHandlerTests()
    {
        _directorRepository = Substitute.For<IDirectorRepository>();
        _azureStorageService = Substitute.For<IAzureStorageService>();
        _handler = new CreateDirectorHandler(_directorRepository, _azureStorageService);
    }

    private static CreateDirectorCommand CreateDirectorCommand()
    {
        var photo = CreateFormFile();
        var command = new CreateDirectorCommand("John", "Doe", new DateTime(2000, 4, 22), "USA");

        return command with { Photo = photo };
    }
}