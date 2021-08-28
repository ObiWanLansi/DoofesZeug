


namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    public sealed class Hour : EntityBase
    {
        public int Value { get; set; }

        public Hour() { }

        public Hour( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Hour( int iValue ) => new(iValue);
        
        public static implicit operator int( Hour value ) => value.Value;
    }
}
