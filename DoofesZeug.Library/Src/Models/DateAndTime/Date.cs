using System;

using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.DateAndTime.Part.Date;



namespace DoofesZeug.Models.DateAndTime
{
    [Builder]
    public class Date : EntityBase
    {
        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        public Day Day { get; set; }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public Month Month { get; set; }

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public Year Year { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Date()
        {
        }


        public Date( DateTime dt )
        {
            this.Day = (uint) dt.Day;
            this.Month = (uint) dt.Month;
            this.Year = (uint) dt.Year;
        }


        public Date( Day day, Month month, Year year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{(uint) this.Day:D2}.{(uint) this.Month:D2}.{(uint) this.Year:D4}";
    }
}

