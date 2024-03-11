namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Photo : Entity
{
    public string FileName { get; private set; }
    public string Url { get; private set; }
    public string Alt { get; private set; }
    public string ContentType { get; private set; }
    
    public ICollection<DirectorPhoto> DirectorPhotos { get; set; }
    public ICollection<MoviePhoto> MoviePhotos { get; set; }

    private Photo()
    {
    }

    private Photo(string fileName, string url, string alt, string contentType)
    {
        FileName = fileName;
        Url = url;
        Alt = alt;
        ContentType = contentType;
    }

    public static Photo Create(string fileName, string url, string alt, string contentType)
        => new(fileName, url, alt, contentType);
}