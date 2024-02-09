using MovieFlow.Bootstrapper;
using MovieFlow.Shared.Infrastructure;
using MovieFlow.Shared.Infrastructure.Modules;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureModules();

builder.Services.AddModules();

var assembly = ModuleLoader.LoadAssemblies(builder.Configuration);
var modules = ModuleLoader.LoadModules(assembly);
builder.Services.AddInfrastructure(assembly, modules);

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