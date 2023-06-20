using System;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Vculp.Api.Bootstrapper.Common
{
    public static class FluentValidationConfiguration
    {
        public static void ConfigureFluentValidation(this IServiceCollection services, Action<IServiceCollection> setupValidatorsAction)
        {
            setupValidatorsAction?.Invoke(services);

            //The property name resolver below is used to prevent the name of the Request Body property
            //For a command being added to the name of the property which fluent validation raises a validation
            //error for in Model State.
            //
            //For example. If a command has a property named Body to represent the body of the request, and Fluent Validation
            //raises a validation error for a property of the request body called Name, then without the property name resolver
            //below, the key added to the ModelState to represent the error would be Body.Name

            //The property name resolve below will string the property name of any properties that have the FromBody attribute defined
            //which will onlt be request bodies inside a commamd object. This ensures that if a validation error for a property called
            //Name is raised, that the key added to the model state is Name, removing the name of the parent property which represents
            //the whole request body object.

            ValidatorOptions.Global.PropertyNameResolver = (type, member, expression) =>
            {
                if (member != null)
                {
                    if (Attribute.IsDefined(member, typeof(FromBodyAttribute)))
                    {
                        return null;
                    }

                    return member.Name;
                }
                return null;
            };
        }
    }
}