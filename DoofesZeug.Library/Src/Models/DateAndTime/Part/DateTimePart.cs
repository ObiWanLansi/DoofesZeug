

namespace DoofesZeug.Models.DateAndTime.Part
{
    public abstract class DateTimePart : EntityBase
    {
        public uint Value { get; set; }


        protected DateTimePart()
        {
        }

        
        protected DateTimePart( uint iValue ) => this.Value = iValue;
    }
}
