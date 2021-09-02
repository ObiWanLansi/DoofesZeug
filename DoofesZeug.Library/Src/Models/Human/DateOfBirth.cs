using System;

using DoofesZeug.Models.Datatypes.DateAndTime;
using DoofesZeug.Models.Datatypes.DateAndTime.Part.Date;



namespace DoofesZeug.Models.Human
{
    public sealed class DateOfBirth : Date
    {
        public DateOfBirth() : base() { }

        public DateOfBirth( DateTime dt ) : base(dt) { }

        public DateOfBirth( Day day, Month month, Year year ) : base(day, month, year) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static implicit operator DateOfBirth( (Day day, Month month, Year year) value ) => new(value.day, value.month, value.year);
    }
}
