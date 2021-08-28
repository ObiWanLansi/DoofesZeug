using System;

using DoofesZeug.Models.Human;

using Newtonsoft.Json;



namespace DoofesZeug.Converter
{
    public sealed class NameConverter : JsonConverter
    {
        private static readonly Type NAME = typeof(Name);

        public override bool CanConvert( Type objectType ) => objectType.BaseType.IsAssignableTo(NAME);

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) => throw new NotImplementedException();

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( value == null )
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(( (Name) value ).Value);
        }
    }
}
