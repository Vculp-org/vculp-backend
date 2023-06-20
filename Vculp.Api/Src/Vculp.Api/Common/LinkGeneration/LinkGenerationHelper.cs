using System;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;

namespace Vculp.Api.Common.LinkGeneration
{
    public class LinkGenerationHelper : ILinkGenerator
    {
        private readonly LinkGenerator _linkGenerator;
        private readonly Uri _baseUrl;

        public LinkGenerationHelper(
            LinkGenerator linkGenerator,
            IOptions<RoutingOptions> routingOptions)
        {
            _linkGenerator = linkGenerator;
            _baseUrl = routingOptions.Value.BaseUrl;
        }

        public string GetLinkToRoute(string routeName, object routeValues)
        {
            if (string.IsNullOrWhiteSpace(routeName))
            {
                throw new ArgumentException($"{nameof(routeName)} must not be null, empty, or contain only whitespace");
            }

            if (routeValues == null)
            {
                throw new ArgumentNullException(nameof(routeValues));
            }

            return new Uri(
                _baseUrl,
                relativeUri: _linkGenerator.GetPathByName(routeName, routeValues)).AbsoluteUri;
        }
    }
}
