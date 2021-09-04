using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime.Part
{
    [Description("")]
    public abstract class DateTimePart : EntityBase
    {
        public uint Value { get; set; }


        protected DateTimePart()
        {
        }

        
        protected DateTimePart( uint iValue ) => this.Value = iValue;
    }
}
