


namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    public sealed class Day : EntityBase
    {
        public int Value { get; set; }

        public Day() { }

        public Day( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Day( int iValue ) => new(iValue);

        public static implicit operator int( Day value ) => value.Value;
    }
}
