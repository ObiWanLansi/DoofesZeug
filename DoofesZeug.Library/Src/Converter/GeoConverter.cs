using System;

using DoofesZeug.Entities.Science.Geographically.Coordinates;

using Newtonsoft.Json;



namespace DoofesZeug.Converter
{
    public sealed class GeoConverter : JsonConverter
    {
        private static readonly Type LATITUDE = typeof(Latitude);

        private static readonly Type LONGITUDE = typeof(Longitude);

        private static readonly Type GEOPOINT2D = typeof(GeoPoint2D);
        
        private static readonly Type GEOPOINT3D = typeof(GeoPoint3D);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert( Type objectType ) => objectType == LATITUDE || objectType == LONGITUDE || objectType == GEOPOINT2D;


        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            if( objectType == LATITUDE )
            {
                return new Latitude(Convert.ToString(reader.Value));
            }

            if( objectType == LONGITUDE )
            {
                return new Longitude(Convert.ToString(reader.Value));
            }

            return objectType == GEOPOINT2D ? new GeoPoint2D(Convert.ToString(reader.Value)) : null;
        }


        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( value == null )
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(value.ToString());
        }
    }
}
