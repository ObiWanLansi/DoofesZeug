using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Description("The day of an date.")]
    [Range(1, 31)]
    public sealed class Day : DateTimePart
    {
        public Day()
        {
        }


        public Day( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Day( uint iValue ) => new(iValue);

        public static implicit operator uint( Day value ) => value.Value;
    }
}
