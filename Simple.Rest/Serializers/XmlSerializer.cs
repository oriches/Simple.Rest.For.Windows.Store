using System.IO;
using System.Runtime.Serialization;

namespace Simple.Rest.Serializers
{
    public sealed class XmlSerializer : ISerializer
    {
        public XmlSerializer()
        {
            ContentType = "application/xml";
        }

        public string ContentType { get; }

        public Stream Serialize<T>(T instance) where T : class
        {
            var serializer = new DataContractSerializer(typeof(T));

            var stream = new MemoryStream();

            serializer.WriteObject(stream, instance);
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }

        public T Deserialize<T>(Stream stream)
        {
            var serializer = new DataContractSerializer(typeof(T));

            return (T) serializer.ReadObject(stream);
        }
    }
}