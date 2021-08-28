


namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    public sealed class Year : EntityBase
    {
        public int Value { get; set; }

        public Year() { }

        public Year( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Year( int iValue ) => new(iValue);
        
        public static implicit operator int( Year value ) => value.Value;
    }
}
