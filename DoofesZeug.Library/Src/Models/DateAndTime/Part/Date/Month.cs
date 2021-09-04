using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Description("The month of an date.")]
    [Range(1, 12)]
    public sealed class Month : DateTimePart
    {
        public Month()
        {
        }


        public Month( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Month( uint iValue ) => new(iValue);

        public static implicit operator uint( Month value ) => value.Value;
    }
}
