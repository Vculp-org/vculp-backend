namespace Vculp.Api.Common.Common.Dtos
{
    public class LinkDto
    {
        public LinkDto(string href, string rel, string method)
        {
            Href = string.IsNullOrWhiteSpace(href) ? string.Empty : href;
            Rel = string.IsNullOrWhiteSpace(rel) ? string.Empty : rel;
            Method = string.IsNullOrWhiteSpace(method) ? string.Empty : method;
        }

        public string Href { get; }
        public string Rel { get; }
        public string Method { get; }
    }
}
