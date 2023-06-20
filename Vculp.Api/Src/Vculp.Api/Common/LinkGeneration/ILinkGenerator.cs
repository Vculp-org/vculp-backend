namespace Vculp.Api.Common.LinkGeneration
{
    public interface ILinkGenerator
    {
        string GetLinkToRoute(string routeName, object routeValues);
    }
}
