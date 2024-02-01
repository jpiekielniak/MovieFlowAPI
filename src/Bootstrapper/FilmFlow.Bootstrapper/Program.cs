using FilmFlow.Bootstrapper;
using FilmFlow.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureModules();

builder.Services.AddModules();

builder.Services.AddInfrastructure();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseStaticFiles();

app.UseInfrastructure(); 

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/swagger/index.html");
        return Task.CompletedTask;
    });
});

app.Run();