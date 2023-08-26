using System;
using System.IO;
using System.Threading.Tasks;
using MessagePack;

namespace Vculp.Api.Common.Serializer;

public class MsgPackSerializer : IMsgPackSerializer
{
    private readonly MessagePackSerializerOptions _messagePackSerializerOptions = MessagePackSerializerOptions.Standard
        .WithSecurity(MessagePackSecurity.UntrustedData)
        .WithResolver(MessagePack.Resolvers.ContractlessStandardResolver.Instance)
        .WithCompression(MessagePackCompression.Lz4BlockArray);

    public byte[] Serialize<T>(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException(nameof(value));
        }

        return MessagePackSerializer.Serialize(value, _messagePackSerializerOptions);
    }

    public T Deserialize<T>(byte[] bytes)
    {
        if (bytes == null)
        {
            throw new ArgumentNullException(nameof(bytes));
        }

        return MessagePackSerializer.Deserialize<T>(bytes, _messagePackSerializerOptions);
    }
}