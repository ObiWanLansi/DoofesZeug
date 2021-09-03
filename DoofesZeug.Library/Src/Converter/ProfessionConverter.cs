using System;

using DoofesZeug.Extensions;
using DoofesZeug.Models.Human.Professions;

using Newtonsoft.Json;



namespace DoofesZeug.Converter
{
    public sealed class ProfessionConverter : JsonConverter
    {
        private static readonly Type PROFESSION = typeof(Profession);

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert( Type objectType ) => objectType.IsAssignableTo(PROFESSION);


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
        /// <exception cref="System.NotImplementedException"></exception>
        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
        {
            //ConstructorInfo constructor = objectType.GetConstructor(new [] { typeof(int) });

            reader.Skip();
            //return constructor?.Invoke(new [] { (object) Convert.ToInt32(reader.Value) });
            return new Unknown();
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

            Profession profession = (Profession) value;
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(profession.Id));
            writer.WriteValue(profession.Id);

            writer.WritePropertyName(nameof(profession.WellKnownProfessionType));
            writer.WriteValue(profession.WellKnownProfessionType.ToString());

            writer.WritePropertyName(nameof(profession.Since));
            writer.WriteValue(profession.Since.ToString());

            writer.WriteEndObject();
        }
    }
}
