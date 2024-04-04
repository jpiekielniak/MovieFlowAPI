using MovieFlow.Modules.Movies.Application.Directors.Commands.ChangeDirectorInformation;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using NSubstitute.ReturnsExtensions;
using static MovieFlow.Modules.Movies.Tests.Unit.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Handlers.Directors.Commands;

public class ChangeDirectorInformationHandlerTests
{
    private async Task Act(ChangeDirectorInformationCommand command)
        => await _handler.Handle(command, CancellationToken.None);

    [Fact]
    public async Task given_valid_data_to_change_should_succeed()
    {
        //Arrange
        var command = ChangeDirectorInformationCommand();
        var director = GetValidDirector();
        _directorRepository.GetAsync(command.DirectorId, Arg.Any<CancellationToken>())
            .Returns(director);
        _directorRepository.CommitAsync(Arg.Any<CancellationToken>())
            .Returns(Task.CompletedTask);
        
        //Act
        await Act(command);
        
        //Assert
        await _directorRepository.Received(1).GetAsync(command.DirectorId, Arg.Any<CancellationToken>());
        await _directorRepository.Received(1).CommitAsync(Arg.Any<CancellationToken>());
        director.FirstName.Value.ShouldBe(command.FirstName);
        director.LastName.Value.ShouldBe(command.LastName);
        director.DateOfBirth.ShouldBe(command.DateOfBirth);
        director.Country.Value.ShouldBe(command.Country);
    }
    
    [Fact]
    public async Task given_invalid_director_id_should_throw_director_not_found_exception()
    {
        //Arrange
        var command = ChangeDirectorInformationCommand();
        _directorRepository.GetAsync(command.DirectorId, Arg.Any<CancellationToken>())
            .ReturnsNull();
        
        //Act
        var exception = await Record.ExceptionAsync(() => Act(command));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<DirectorNotFoundException>();
        await _directorRepository.Received(1).GetAsync(command.DirectorId, Arg.Any<CancellationToken>());
        await _directorRepository.DidNotReceive().CommitAsync(Arg.Any<CancellationToken>());
    }

    private readonly IRequestHandler<ChangeDirectorInformationCommand> _handler;
    private readonly IDirectorRepository _directorRepository;

    public ChangeDirectorInformationHandlerTests()
    {
        _directorRepository = Substitute.For<IDirectorRepository>();
        _handler = new ChangeDirectorInformationHandler(_directorRepository);
    }

    private static ChangeDirectorInformationCommand ChangeDirectorInformationCommand()
        => new("Director Name", "Director Surname", new DateTime(1970, 2, 15), "Director Country");
}