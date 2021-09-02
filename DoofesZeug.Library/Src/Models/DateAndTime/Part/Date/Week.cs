using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Range(1, 53)]
    public sealed class Week : DateTimePart
    {
        public Week()
        {
        }


        public Week( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Week( int iValue ) => new(iValue);

        public static implicit operator int( Week value ) => value.Value;
    }
}
