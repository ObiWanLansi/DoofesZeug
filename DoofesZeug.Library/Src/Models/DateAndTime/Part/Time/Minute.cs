using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Description("The minutes of an time.")]
    [Range(0, 59)]
    public sealed class Minute : DateTimePart
    {
        public Minute()
        {
        }


        public Minute( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Minute( uint iValue ) => new(iValue);

        public static implicit operator uint( Minute value ) => value.Value;
    }
}
