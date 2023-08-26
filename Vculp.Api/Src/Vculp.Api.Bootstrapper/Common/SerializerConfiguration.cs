using Microsoft.Extensions.DependencyInjection;
using Vculp.Api.Common.Serializer;

namespace Vculp.Api.Bootstrapper.Common;

public static class SerializerConfiguration
{
    public static void AddSerializerConfiguration(this IServiceCollection services)
    {
        services.AddScoped<IMsgPackSerializer, MsgPackSerializer>();
    }
}