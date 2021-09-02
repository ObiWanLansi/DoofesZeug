using System;
using System.Linq;

using DoofesZeug.Converter;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;



namespace DoofesZeug.Extensions
{
    public static class JsonExtension
    {
        private static readonly JsonSerializerSettings settings = new()
        {
            Formatting = Formatting.Indented
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes the <see cref="JsonExtension"/> class.
        /// </summary>
        static JsonExtension()
        {
            settings.Converters.Add(new StringEnumConverter());
            settings.Converters.Add(new NameConverter());
            settings.Converters.Add(new DateTimePartConverter());
            settings.Converters.Add(new UnixTimestampConverter());
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to pretty json.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <returns></returns>
        public static string ToPrettyJson( this object o ) => JsonConvert.SerializeObject(o, settings);


        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strJSON">The string json.</param>
        /// <returns></returns>
        public static T FromJson<T>( this string strJSON )
        {
            Type t = typeof(T);
            return (T) JsonConvert.DeserializeObject(strJSON, t, settings.Converters.ToArray());
        }
    }
}
