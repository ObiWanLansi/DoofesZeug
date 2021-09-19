using System;

using DoofesZeug.Datatypes.Misc;

using Newtonsoft.Json;



namespace DoofesZeug.Converter
{
    public sealed class UnitPrefixConverter : JsonConverter
    {
        private static readonly Type UNITPREFIX = typeof(UnitPrefix);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert( Type objectType ) => objectType == UNITPREFIX;


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
            return Convert.ToString(reader.Value) switch
            {
                nameof(UnitPrefixes.Exa) => UnitPrefixes.Exa,
                nameof(UnitPrefixes.Peta) => UnitPrefixes.Peta,
                nameof(UnitPrefixes.Tera) => UnitPrefixes.Tera,
                nameof(UnitPrefixes.Giga) => UnitPrefixes.Giga,
                nameof(UnitPrefixes.Mega) => UnitPrefixes.Mega,
                nameof(UnitPrefixes.Kilo) => UnitPrefixes.Kilo,
                nameof(UnitPrefixes.Base) => UnitPrefixes.Base,
                nameof(UnitPrefixes.Centi) => UnitPrefixes.Centi,
                nameof(UnitPrefixes.Milli) => UnitPrefixes.Milli,
                nameof(UnitPrefixes.Mikro) => UnitPrefixes.Mikro,
                nameof(UnitPrefixes.Nano) => UnitPrefixes.Nano,
                nameof(UnitPrefixes.Piko) => UnitPrefixes.Piko,
                nameof(UnitPrefixes.Femto) => UnitPrefixes.Femto,
                nameof(UnitPrefixes.Atto) => UnitPrefixes.Atto,
                _ => null,
            };
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

            writer.WriteValue(( value as UnitPrefix ).Name);
        }
    }
}
