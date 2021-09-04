using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime;
using DoofesZeug.Models.DateAndTime.Part.Date;



namespace DoofesZeug.Models.Human
{
    [Description("An dateofbirth for creatures.")]
    public sealed class DateOfBirth : Date
    {
        public DateOfBirth() : base() { }

        public DateOfBirth( Date date ) : base(date) { }

        public DateOfBirth( DateTime dt ) : base(dt) { }

        public DateOfBirth( Day day, Month month, Year year ) : base(day, month, year) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static implicit operator DateOfBirth( (Day day, Month month, Year year) value ) => new(value.day, value.month, value.year);

        //public static implicit operator DateOfBirth(string strDateOfBirth ){
    }
}
