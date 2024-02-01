using System.Reflection;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace FilmFlow.Shared.Infrastructure.Api;

internal class InternalControllerFeatureProvider : ControllerFeatureProvider
{

    protected override bool IsController(TypeInfo typeInfo)
    {
        var isCustomController = !typeInfo.IsAbstract;
        return isCustomController || base.IsController(typeInfo);
    }
} 

