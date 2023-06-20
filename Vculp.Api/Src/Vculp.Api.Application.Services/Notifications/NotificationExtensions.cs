using System.Collections.Generic;
using System.Threading.Tasks;
using RazorLight;
using Vculp.Api.Common.Common.Models.Email;

namespace Vculp.Api.Application.Services.Notifications
{
    public static class NotificationExtensions
    {
        public static async Task<string> GetTemplate<T>(this IRazorLightEngine razorLightEngine, string templateKey,
            T model)
        {
            // Try to find template.
            var cacheResult = razorLightEngine.Handler.Cache.RetrieveTemplate(templateKey);
            if (cacheResult.Success)
            {
                var templatePage = cacheResult.Template.TemplatePageFactory();
                // If template exists render template
                return await razorLightEngine.RenderTemplateAsync(templatePage, model);
            }
            else
            {
                // Compile and generate template
                return await razorLightEngine.CompileRenderAsync(templateKey, model);
            }
        }

        public static IList<EmbeddedResource> GetEmbeddedResources()
        {

            var embeddedResource = new List<EmbeddedResource>
            {
                new EmbeddedResource
                {
                    Key = "GpsPin", Path = NotificationConstants.AssetsFooterGpsPin,
                    ContentType = NotificationConstants.ImagePng
                },
                new EmbeddedResource
                {
                    Key = "logo", Path = NotificationConstants.AssetsFooterLogo,
                    ContentType = NotificationConstants.ImagePng
                },
                new EmbeddedResource
                {
                    Key = "Phone", Path = NotificationConstants.AssetsFooterPhone,
                    ContentType = NotificationConstants.ImagePng
                },
                new EmbeddedResource
                {
                    Key = "Separator", Path = NotificationConstants.AssetsFooterSeparator,
                    ContentType = NotificationConstants.ImagePng
                },
                new EmbeddedResource
                {
                    Key = "Slogan", Path = NotificationConstants.AssetsFooterSlogan,
                    ContentType = NotificationConstants.ImagePng
                },
                new EmbeddedResource
                {
                    Key = "Web", Path = NotificationConstants.AssetsFooterWeb,
                    ContentType = NotificationConstants.ImagePng
                }
            };
            return embeddedResource;
        }
    }
}