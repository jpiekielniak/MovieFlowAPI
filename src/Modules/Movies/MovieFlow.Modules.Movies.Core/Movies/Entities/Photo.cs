namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Photo : Entity
{
    public string FileName { get; private set; }
    public string Url { get; private set; }
    public string Alt { get; private set; }
    public string ContentType { get; private set; }
    
    public Guid? MovieId { get; private set; }  
    public Movie Movie { get; private set; }  

    public Guid? DirectorId { get; private set; } 
    public Director Director { get; private set; }
    
    public Guid? ActorId { get; private set; }
    public Actor Actor { get; private set; }
    
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