


namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    public sealed class Second : EntityBase
    {
        public int Value { get; set; }

        public Second() { }

        public Second( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Second( int iValue ) => new(iValue);
        
        public static implicit operator int( Second value ) => value.Value;
    }
}
