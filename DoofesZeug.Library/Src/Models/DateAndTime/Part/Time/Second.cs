using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Range(0, 59)]
    public sealed class Second : DateTimePart
    {
        public Second()
        {
        }


        public Second( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Second( int iValue ) => new(iValue);

        public static implicit operator int( Second value ) => value.Value;
    }
}
