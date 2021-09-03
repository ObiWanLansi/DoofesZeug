using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Range(0, 9999)]
    public sealed class Year : DateTimePart
    {
        public Year()
        {
        }


        public Year( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Year( uint iValue ) => new(iValue);

        public static implicit operator uint( Year value ) => value.Value;
    }
}
