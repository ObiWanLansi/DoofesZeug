


namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    public sealed class Second : DateTimePart
    {
        public Second() { }

        public Second( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Second( int iValue ) => new(iValue);

        public static implicit operator int( Second value ) => value.Value;
    }
}
