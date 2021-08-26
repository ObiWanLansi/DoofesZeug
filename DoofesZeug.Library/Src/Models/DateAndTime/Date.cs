using System;

using DoofesZeug.Attributes;



namespace DoofesZeug.Models.DateAndTime
{
    [Builder]
    public class Date
    {
        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        public int Day { get; init; }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public int Month { get; init; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public int Year { get; init; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Date()
        {
        }


        public Date( DateTime dt )
        {
            this.Day = dt.Day;
            this.Month = dt.Month;
            this.Year = dt.Year;
        }


        public Date( int day, int month, int year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static public Date From( int day, int month, int year ) => new(year, month, day);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.Day:D2}.{this.Month:D2}.{this.Year:D4}";
    }
}

