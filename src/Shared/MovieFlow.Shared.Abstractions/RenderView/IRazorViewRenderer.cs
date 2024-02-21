namespace MovieFlow.Shared.Abstractions.RenderView;

public interface IRazorViewRenderer
{
    Task<string> RenderViewToStringAsync<TModel>(string viewName, TModel model);
}