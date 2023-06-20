using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Vculp.Api.Common
{
    public class TagByApiExplorerSettingsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiGroupNames = context
                .MethodInfo.DeclaringType.GetCustomAttributes(true)
                .Union(context.MethodInfo.GetCustomAttributes(true))
                .OfType<ApiExplorerSettingsAttribute>()
                .ToList();


            if (apiGroupNames.Count == 0)
            {
                return;
            }

            var tags = operation.Tags?.Select(a => a).ToList() ?? new List<OpenApiTag>();

            var controllerDescriptor = context.ApiDescription.GetProperty<ControllerActionDescriptor>();

            if (controllerDescriptor != null)
            {
                tags.RemoveAll(t => t.Name == controllerDescriptor.ControllerName);

                foreach (var item in apiGroupNames)
                {
                    var groupTags = tags.Where(t => t.Name == item.GroupName);

                    foreach (var tag in groupTags)
                    {
                        tags.Remove(tag);
                    }
                }

                operation.Tags = tags;
            }
        }
    }
}
