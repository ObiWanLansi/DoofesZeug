using System;

using DoofesZeug.Models.DateAndTime.Part;

using Newtonsoft.Json;



namespace DoofesZeug.Converter
{
    public sealed class DateTimePartConverter : JsonConverter
    {
        private static readonly Type DATETIMEPART = typeof(DateTimePart);

        public override bool CanConvert( Type objectType ) => objectType.BaseType.IsAssignableTo(DATETIMEPART);

        public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer ) => throw new NotImplementedException();

        public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
        {
            if( value == null )
            {
                writer.WriteNull();
                return;
            }

            writer.WriteValue(( (DateTimePart) value ).Value);
        }
    }
}
