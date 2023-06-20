using Vculp.Api.Common.Common.Dtos;

namespace Vculp.Api.Common.Common
{
    public interface IHateoasLinkGenerator<T>
        where T : LinkedResourceDto
    {
        T GenerateLinks(T dto);
    }
}
