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
        public Day Day { get; set; } = 1;

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>
        /// The month.
        /// </value>
        public Month Month { get; set; } = 1;

        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>
        /// The year.
        /// </value>
        public Year Year { get; set; } = 1;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Date()
        {
        }


        public Date( Date date )
        {
            this.Day = date.Day;
            this.Month = date.Month;
            this.Year = date.Year;
        }


        public Date( DateTime dt )
        {
            this.Day = (uint) dt.Day;
            this.Month = (uint) dt.Month;
            this.Year = (uint) dt.Year;
        }


        public Date( uint day, uint month, uint year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }


        public Date( Day day, Month month, Year year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{Day, Month, Year}"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Date( (Day day, Month month, Year year) value ) => new(value.day, value.month, value.year);


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Date"/>.
        /// </summary>
        /// <param name="strContent">The string date.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Date( string strContent )
        {
            // 0123456789
            // 15.10.1974

            if( strContent.Length != 10 )
            {
                throw new ArgumentException("The length of the date ist not ten characters.", nameof(strContent));
            }

            if( strContent [2] == '.' == false || strContent [5] == '.' == false )
            {
                throw new ArgumentException("The date have not the right format 'dd.mm.yyyy'.", nameof(strContent));
            }

            uint day = Convert.ToUInt32(strContent.Substring(0, 2));
            uint month = Convert.ToUInt32(strContent.Substring(3, 2));
            uint year = Convert.ToUInt32(strContent.Substring(6, 4));

            return new Date(day, month, year);
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{(uint) this.Day:D2}.{(uint) this.Month:D2}.{(uint) this.Year:D4}";
    }
}

