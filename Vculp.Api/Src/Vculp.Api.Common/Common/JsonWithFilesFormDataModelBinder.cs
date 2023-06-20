using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Vculp.Api.Common.Common
{
    public class JsonWithFilesFormDataModelBinder : IModelBinder
    {
        private readonly FormFileModelBinder _formFileModelBinder;

        public JsonWithFilesFormDataModelBinder(ILoggerFactory loggerFactory)
        {
            _formFileModelBinder = new FormFileModelBinder(loggerFactory);
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
                throw new ArgumentNullException(nameof(bindingContext));

            var valueResult = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);
            
            if (valueResult == ValueProviderResult.None)
            {
                var message = bindingContext.ModelMetadata.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(bindingContext.FieldName);
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, message);
                return;
            }
            
            var rawValue = valueResult.FirstValue;

            var model = JsonConvert.DeserializeObject(rawValue, bindingContext.ModelType);

            foreach (var property in bindingContext.ModelMetadata.Properties)
            {
                if (bindingContext.ActionContext.RouteData.Values.ContainsKey(property.PropertyName)
                    && Guid.TryParse(bindingContext.ActionContext.RouteData.Values[property.PropertyName].ToString(), out Guid id))
                {
                    property.PropertySetter(model, id);
                }

                if (property.ModelType != typeof(IFormFile))
                    continue;

                var fieldName = property.BinderModelName ?? property.PropertyName;
                var modelName = fieldName;
                var propertyModel = property.PropertyGetter(bindingContext.Model);
                ModelBindingResult propertyResult;
                using (bindingContext.EnterNestedScope(property, fieldName, modelName, propertyModel))
                {
                    await _formFileModelBinder.BindModelAsync(bindingContext);
                    propertyResult = bindingContext.Result;
                }

                if (propertyResult.IsModelSet)
                {
                    property.PropertySetter(model, propertyResult.Model);
                }
                else if (property.IsBindingRequired)
                {
                    var message = property.ModelBindingMessageProvider.MissingBindRequiredValueAccessor(fieldName);
                    bindingContext.ModelState.TryAddModelError(modelName, message);
                }
            }

            bindingContext.Result = ModelBindingResult.Success(model);
        }
    }
}
