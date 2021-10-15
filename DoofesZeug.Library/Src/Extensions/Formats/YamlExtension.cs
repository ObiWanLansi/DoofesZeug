using YamlDotNet.Serialization;



namespace DoofesZeug.Extensions.Formats
{
    public static class YamlExtension
    {
        public static string ToPrettyYaml( this object o ) => new SerializerBuilder().Build().Serialize(o);
    }
}
