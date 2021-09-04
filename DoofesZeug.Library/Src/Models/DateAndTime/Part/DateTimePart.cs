using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime.Part
{
    [Description("An abstract base class for all other parts of an date or an time.")]
    public abstract class DateTimePart : EntityBase
    {
        public uint Value { get; set; }


        protected DateTimePart()
        {
        }


        protected DateTimePart( uint iValue ) => this.Value = iValue;

        
        public override string ToString() => $"{Value}";
    }
}
