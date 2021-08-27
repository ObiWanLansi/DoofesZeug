using System;

using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Human
{
    public sealed class DateOfBirth : Date
    {
        public DateOfBirth() : base() { }


        public DateOfBirth( DateTime dt ) : base(dt) { }


        public DateOfBirth( int day, int month, int year ) : base(day, month, year) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator DateOfBirth( (int day, int month, int year) value ) => new(value.year, value.month, value.day);
    }
}
