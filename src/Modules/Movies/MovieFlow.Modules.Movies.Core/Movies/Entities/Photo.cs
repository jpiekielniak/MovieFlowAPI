using MovieFlow.Shared.Abstractions.Kernel;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Photo : Entity
{
    public string FileName { get; private set; }
    public string Url { get; private set; }
    public string Alt { get; private set; }
    public string ContentType { get; private set; }
    public string Content { get; private set; }
   

    private Photo()
    {
    }

    private Photo(string fileName, string url, string alt, string contentType, string content)
    {
        FileName = fileName;
        Url = url;
        Alt = alt;
        ContentType = contentType;
        Content = content;
    }

    public static Photo Create(string fileName, string url, string alt, string contentType, string content) =>
        new(fileName, url, alt, contentType, content);
}