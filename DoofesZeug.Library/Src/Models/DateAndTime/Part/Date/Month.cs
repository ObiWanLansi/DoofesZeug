


namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    public sealed class Month : DateTimePart
    {
        public Month() { }

        public Month( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Month( int iValue ) => new(iValue);
        
        public static implicit operator int( Month value ) => value.Value;
    }
}
