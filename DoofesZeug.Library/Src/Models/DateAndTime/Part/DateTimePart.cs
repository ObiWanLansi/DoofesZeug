

namespace DoofesZeug.Models.DateAndTime.Part
{
    public abstract class DateTimePart : EntityBase
    {
        public int Value { get; set; }


        protected DateTimePart()
        {
        }

        
        protected DateTimePart( int iValue ) => this.Value = iValue;
    }
}
