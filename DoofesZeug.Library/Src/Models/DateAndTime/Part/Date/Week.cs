using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Description("The week of an date in the year.")]
    [Range(1, 53)]
    public sealed class Week : DateTimePart
    {
        public Week()
        {
        }


        public Week( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Week( uint iValue ) => new(iValue);

        public static implicit operator uint( Week value ) => value.Value;
    }
}
