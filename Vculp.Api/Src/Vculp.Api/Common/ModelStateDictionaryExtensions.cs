using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Common.Common;

namespace Vculp.Api.Common
{
    public static class ModelStateDictionaryExtensions
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<IOperationError> operationErrors)
        {
            if (modelState == null)
            {
                return;
            }

            if (operationErrors == null)
            {
                throw new ArgumentNullException(nameof(operationErrors));
            }

            foreach (var error in operationErrors)
            {
                modelState.AddModelError(error.ErrorKey, error.ErrorMessage);
            }
        }
    }
}
