using System.IO;

namespace Simple.Rest.Serializers
{
    public interface ISerializer
    {
        string ContentType { get; }

        Stream Serialize<T>(T instance) where T : class;

        T Deserialize<T>(Stream stream);
    }
}