using System.IO;

namespace Vculp.Api.Common.Common
{
    public interface IFileSignatureValidator
    {
        bool ValidateSignature(string fileExtension, Stream content);
    }
}
