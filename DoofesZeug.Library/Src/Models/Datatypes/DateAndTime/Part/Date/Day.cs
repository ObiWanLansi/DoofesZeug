using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.Datatypes.DateAndTime.Part.Date
{
    [Range(1, 31)]
    public sealed class Day : DateTimePart
    {
        public Day() { }

        public Day( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Day( int iValue ) => new(iValue);

        public static implicit operator int( Day value ) => value.Value;
    }
}
