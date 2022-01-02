using System;
using System.Collections.Generic;

using System.Globalization;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Extensions;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace DoofesZeug.Tools.Misc
{
    [Description("Our known and implemented color schemes of the color brewer definition.")]
    public enum ColorBrewerScheme : byte
    {
        Spectral, RdYlGn, RdBu,
        PiYG, PRGn, RdYlBu,
        BrBG, RdGy, PuOr,
        Set2, Accent, Set1,
        Set3, Dark2, Paired,
        Pastel2, Pastel1, OrRd,
        PuBu, BuPu, Oranges,
        BuGn, YlOrBr, YlGn,
        Reds, RdPu, Greens,
        YlGnBu, Purples, GnBu,
        Greys, YlOrRd, PuRd,
        Blues, PuBuGn
    }



    [Description("An unknown enumeration of the color brewer mechanism.")]
    public enum TypeEnum { Div, Qual, Seq };



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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static Dictionary<string, ColorBrewer> FromJson( string json ) => JsonConvert.DeserializeObject<Dictionary<string, ColorBrewer>>(json, Converter.Settings);


        /// <summary>
        /// Loads from resource.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, ColorBrewer> LoadFromResource()
        {
            string strColorBrewerJson = ApplicationResource.ReadResourceAsString("DoofesZeug.Resources.colorbrewer.json");
            return JsonConvert.DeserializeObject<Dictionary<string, ColorBrewer>>(strColorBrewerJson, Converter.Settings);
        }
    }


    public sealed class ColorBrewerCatalog : Dictionary<ColorBrewerScheme, ColorBrewer>
    {
        private ColorBrewerCatalog()
        {
        }

        private static ColorBrewerCatalog instance = null;


        public static ColorBrewerCatalog Instance
        {
            get
            {
                if( instance == null )
                {
                    instance = LoadColorBrewerCatalog();
                }
                return instance;
            }
        }


        private static ColorBrewerCatalog LoadColorBrewerCatalog()
        {
            ColorBrewerCatalog cbc = new();
            ColorBrewer.LoadFromResource().ForEach(( scheme, brewer ) => cbc.Add((ColorBrewerScheme) Enum.Parse(typeof(ColorBrewerScheme), scheme), brewer));
            return cbc;
        }
    }


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

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

            return value switch
            {
                "div" => TypeEnum.Div,
                "qual" => TypeEnum.Qual,
                "seq" => TypeEnum.Seq,
                _ => throw new Exception("Cannot unmarshal type TypeEnum"),
            };
        }

        public override void WriteJson( JsonWriter writer, object untypedValue, JsonSerializer serializer ) => throw new NotImplementedException();

        public static readonly TypeEnumConverter Singleton = new();
    }
}
