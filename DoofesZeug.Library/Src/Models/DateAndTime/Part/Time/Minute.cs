using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Range(0, 59)]
    public sealed class Minute : DateTimePart
    {
        public Minute()
        {
        }


        public Minute( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Minute( int iValue ) => new(iValue);

        public static implicit operator int( Minute value ) => value.Value;
    }
}
