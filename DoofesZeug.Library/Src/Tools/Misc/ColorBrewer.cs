using System;
using System.Collections.Generic;

using System.Globalization;

using DoofesZeug.Attributes.Documentation;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace DoofesZeug.Tools.Misc
{
    [Description("An stupid helper class to load and user the color brewer definition.")]
    public class ColorBrewer
    {
        [JsonProperty("3")]
        public List<string> The3 { get; set; }

        [JsonProperty("4")]
        public List<string> The4 { get; set; }

        [JsonProperty("5")]
        public List<string> The5 { get; set; }

        [JsonProperty("6")]
        public List<string> The6 { get; set; }

        [JsonProperty("7")]
        public List<string> The7 { get; set; }

        [JsonProperty("8")]
        public List<string> The8 { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("9", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> The9 { get; set; }

        [JsonProperty("10", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> The10 { get; set; }

        [JsonProperty("11", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> The11 { get; set; }

        [JsonProperty("12", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> The12 { get; set; }

        public static Dictionary<string, ColorBrewer> FromJson( string json ) => JsonConvert.DeserializeObject<Dictionary<string, ColorBrewer>>(json, Converter.Settings);
    }


    [Description("An unknown enumeration of the color brewer mechanism.")]
    public enum TypeEnum { Div, Qual, Seq };



    //public static class Serialize
    //{
    //    public static string ToJson( this Dictionary<string, ColorBrewer> self ) => JsonConvert.SerializeObject(self, Converter.Settings);
    //}


    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new()
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }


    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert( Type t ) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson( JsonReader reader, Type t, object existingValue, JsonSerializer serializer )
        {
            if( reader.TokenType == JsonToken.Null )
            {
                return null;
            }

            string value = serializer.Deserialize<string>(reader);

            switch( value )
            {
                case "div":
                    return TypeEnum.Div;
                case "qual":
                    return TypeEnum.Qual;
                case "seq":
                    return TypeEnum.Seq;
            }

            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson( JsonWriter writer, object untypedValue, JsonSerializer serializer ) => throw new NotImplementedException();
        //public override void WriteJson( JsonWriter writer, object untypedValue, JsonSerializer serializer )
        //{
        //    if( untypedValue == null )
        //    {
        //        serializer.Serialize(writer, null);
        //        return;
        //    }

        //    TypeEnum value = (TypeEnum) untypedValue;

        //    switch( value )
        //    {
        //        case TypeEnum.Div:
        //            serializer.Serialize(writer, "div");
        //            return;
        //        case TypeEnum.Qual:
        //            serializer.Serialize(writer, "qual");
        //            return;
        //        case TypeEnum.Seq:
        //            serializer.Serialize(writer, "seq");
        //            return;
        //    }

        //    throw new Exception("Cannot marshal type TypeEnum");
        //}

        public static readonly TypeEnumConverter Singleton = new();
    }
}
