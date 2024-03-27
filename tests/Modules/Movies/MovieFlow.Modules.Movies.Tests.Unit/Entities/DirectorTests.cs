using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Shared;
using MovieFlow.Shared.Abstractions.Exceptions;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;
using static MovieFlow.Modules.Movies.Tests.Unit.Entities.Extensions.Extensions;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class DirectorTests
{
    private static Director Act(string firstName, string lastName, DateTime dateOfBirth, Country country)
        => Director.Create(firstName, lastName, dateOfBirth, country);

    private static void Act(Director director, Photo photo) => director.AddPhoto(photo);

    [Fact]
    public void given_valid_director_should_succeed()
    {
        //Arrange
        const string firstName = "John";
        const string lastName = "Doe";
        const string country = "USA";
        var dateOfBirth = new DateTime(1970, 4, 20);
        
        //Act
        var director = Act(firstName, lastName, dateOfBirth, country);
        
        //Assert
        director.ShouldNotBeNull();
        director.ShouldBeOfType<Director>();
        director.Id.ShouldBeAssignableTo<Guid>();
    }
    
    [Fact]
    public void given_null_photo_should_throw_exception()
    {
        //Arrange
        var director = GetValidDirector();
        
        //Act
        var exception = Record.Exception(() => Act(director, null));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<PhotoCannotBeNullException>();
    }

    [Fact]
    public void given_valid_photo_should_succeed()
    {
        //Arrange
        var director = GetValidDirector();
        var photo = CreatePhoto();
        
        //Act
        Act(director, photo);
        
        //Assert
        director.Photos.ShouldNotBeNull();
        director.Photos.ShouldContain(photo);
        director.Photos.ShouldHaveSingleItem();
    }
    
    [Fact]
    public void given_valid_information_to_change_should_succeed()
    {
        //Arrange
        var director = GetValidDirector();
        const string firstName = "Jane";
        const string lastName = "Elen";
        var dateOfBirth = new DateTime(1975, 4, 20);
        const string country = "Canada";
        
        //Act
        director.ChangeInformation(firstName, lastName, dateOfBirth, country);
        
        //Assert
        director.FirstName.Value.ShouldBe(firstName);
        director.LastName.Value.ShouldBe(lastName);
        director.DateOfBirth.ShouldBe(dateOfBirth);
        director.Country.Value.ShouldBe(country);
    }

    [Fact]
    public void given_null_properties_should_fail()
    {
        //Act
        var exception = Record.Exception(() => Act(null, null, new DateTime(1970,5,15), null));
        
        //Assert
        exception.ShouldNotBeNull();
        exception.ShouldBeAssignableTo<MovieFlowException>();
    }
}