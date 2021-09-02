


namespace DoofesZeug.Models.Datatypes.DateAndTime.Part.Time
{
    public sealed class Hour : DateTimePart
    {
        public Hour() { }

        public Hour( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Hour( int iValue ) => new(iValue);
        
        public static implicit operator int( Hour value ) => value.Value;
    }
}
