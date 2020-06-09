using API.Controllers;
using Core.Core;
using Core.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace API.Extensions
{
   public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
{
    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    {
        var currentAssembly = typeof(BaseEntity).Assembly;
        var candidates = currentAssembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());
            
        foreach (var candidate in candidates)
        {
             feature.Controllers.Add(
                 typeof(BaseController<>).MakeGenericType(candidate).GetTypeInfo()
             );
        }
    }
}
}
