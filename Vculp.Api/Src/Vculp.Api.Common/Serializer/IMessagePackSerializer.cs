using System.Threading.Tasks;

namespace Vculp.Api.Common.Serializer;

public interface IMsgPackSerializer
{
    byte[] Serialize<T>(T value);

    T Deserialize<T>(byte[] bytes);
}