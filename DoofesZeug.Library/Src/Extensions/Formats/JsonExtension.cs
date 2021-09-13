using System;
using System.Collections.Generic;
using System.Linq;

using DoofesZeug.Converter;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace DoofesZeug.Extensions.Formats
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerSettings settingsDefault = new();

        private static readonly JsonSerializerSettings settingsPretty = new()
        {
            Formatting = Formatting.Indented
        };

        private static readonly List<JsonConverter> converter = new()
        {
            new StringEnumConverter(),
            new NameConverter(),
            new ProfessionConverter(),
            new DateOfBirthConverter(),
            new DateTimePartConverter(),
            new UnixTimestampConverter(),
            new GeoConverter()
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes the <see cref="JsonExtension"/> class.
        /// </summary>
        static JsonExtension()
        {
            foreach( JsonConverter conv in converter )
            {
                settingsPretty.Converters.Add(conv);
                settingsDefault.Converters.Add(conv);
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to pretty json.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string ToPrettyJson( this object o ) => JsonConvert.SerializeObject(o, settingsPretty);

        /// <summary>
        /// Converts to json.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string ToJson( this object o ) => JsonConvert.SerializeObject(o, settingsDefault);


        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJSON">The string json.</param>
        /// <returns></returns>
        public static T FromJson<T>( this string strJSON ) => (T) JsonConvert.DeserializeObject(strJSON, typeof(T), settingsDefault.Converters.ToArray());


        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="strJSON">The string json.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static object FromJson( this string strJSON, Type type ) => JsonConvert.DeserializeObject(strJSON, type, settingsDefault.Converters.ToArray());


        /// <summary>
        /// Converts to readablejson.
        /// </summary>
        /// <param name="strJsonOriginal">The string json original.</param>
        /// <returns></returns>
        public static string ToReadableJson( this string strJsonOriginal )
        {
            object obj = JsonConvert.DeserializeObject(strJsonOriginal);
            return JsonConvert.SerializeObject(obj, settingsPretty);
        }
    }
}
