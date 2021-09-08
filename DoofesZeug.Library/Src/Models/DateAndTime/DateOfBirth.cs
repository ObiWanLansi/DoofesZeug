using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime.Part.Date;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An date of birth for creatures.")]
    public sealed class DateOfBirth : Date
    {
        public DateOfBirth() : base() { }

        public DateOfBirth( Date date ) : base(date) { }

        public DateOfBirth( DateTime dt ) : base(dt) { }

        public DateOfBirth( Day day, Month month, Year year ) : base(day, month, year) { }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="DateTime"/> to <see cref="DateOfBirth"/>.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateOfBirth( DateTime dt ) => new((uint) dt.Day, (uint) dt.Month, (uint) dt.Year);


        /// <summary>
        /// Performs an implicit conversion from <see cref="(DoofesZeug.Models.DateAndTime.Part.Date.Day day, DoofesZeug.Models.DateAndTime.Part.Date.Month month, DoofesZeug.Models.DateAndTime.Part.Date.Year year)"/> to <see cref="DoofesZeug.Models.Human.DateOfBirth"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateOfBirth( (Day day, Month month, Year year) value ) => new(value.day, value.month, value.year);
    }
}
