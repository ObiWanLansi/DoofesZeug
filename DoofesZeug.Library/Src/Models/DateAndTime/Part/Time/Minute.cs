


namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    public sealed class Minute : EntityBase
    {
        public int Value { get; set; }

        public Minute() { }

        public Minute( int iInitalValue ) => this.Value = iInitalValue;

        public static implicit operator Minute( int iValue ) => new(iValue);
        
        public static implicit operator int( Minute value ) => value.Value;
    }
}
