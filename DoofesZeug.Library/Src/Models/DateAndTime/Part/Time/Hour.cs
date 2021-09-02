using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Range(0, 23)]
    public sealed class Hour : DateTimePart
    {
        public Hour()
        { 
        }


        public Hour( uint iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Hour( uint iValue ) => new(iValue);

        public static implicit operator uint( Hour value ) => value.Value;
    }
}
