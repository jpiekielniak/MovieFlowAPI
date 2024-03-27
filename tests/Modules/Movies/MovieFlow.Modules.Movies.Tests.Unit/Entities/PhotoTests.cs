using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Tests.Unit.Entities;

public class PhotoTests
{
    [Fact]
    public void given_valid_photo_should_succeed()
    {
        //Arrange
        const string fileName = "fileName";
        const string url = "url";
        const string alt = "alt";
        const string contentType = "contentType";
        
        //Act
        var photo = Photo.Create(fileName, url, alt, contentType);
        
        //Assert
        photo.ShouldNotBeNull();
        photo.ShouldBeOfType<Photo>();
        photo.Id.ShouldBeAssignableTo<Guid>();
        photo.Id.ShouldNotBe(Guid.Empty);
    }
}