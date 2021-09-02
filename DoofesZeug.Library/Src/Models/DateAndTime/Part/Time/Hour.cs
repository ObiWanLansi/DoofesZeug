using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Range(0, 23)]
    public sealed class Hour : DateTimePart
    {
        public Hour()
        { 
        }


        public Hour( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Hour( int iValue ) => new(iValue);

        public static implicit operator int( Hour value ) => value.Value;
    }
}
