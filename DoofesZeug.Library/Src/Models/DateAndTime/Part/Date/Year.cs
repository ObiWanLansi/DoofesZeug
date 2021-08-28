


namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    public sealed class Year : DateTimePart
    {
        public Year() { }

        public Year( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Year( int iValue ) => new(iValue);
        
        public static implicit operator int( Year value ) => value.Value;
    }
}
