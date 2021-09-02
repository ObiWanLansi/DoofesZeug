using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Range(0, 59)]
    public sealed class Second : DateTimePart
    {
        public Second()
        {
        }


        public Second( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Second( uint iValue ) => new(iValue);

        public static implicit operator uint( Second value ) => value.Value;
    }
}
