using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Extensions;
using DoofesZeug.Models.DateAndTime.Part.Date;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An date entity with day, month and a year (15.12.1948).")]
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


        /// <summary>
        /// The minimum
        /// </summary>
        public static readonly Date Min = new((uint) 01, 01, 0001);

        /// <summary>
        /// The maximum
        /// </summary>
        public static readonly Date Max = new((uint) 31, 12, 9999);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        public Date()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="date">The date.</param>
        public Date( Date date )
        {
            this.Day = date.Day;
            this.Month = date.Month;
            this.Year = date.Year;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public Date( DateTime dt )
        {
            this.Day = (uint) dt.Day;
            this.Month = (uint) dt.Month;
            this.Year = (uint) dt.Year;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        public Date( uint day, uint month, uint year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Date"/> class.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        public Date( Day day, Month month, Year year )
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the specified string content.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// The length of the date ist not ten characters., nameof(strContent)
        /// or
        /// The length of the date ist not ten characters., nameof(strContent)
        /// </exception>
        public static Date From( string strContent )
        {
            // 0123456789
            // 15.10.1974

            if( strContent.IsEmpty() || strContent.EqualsIgnoreCase("null") )
            {
                return null;
            }

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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.DateTime"/> to <see cref="DoofesZeug.Models.DateAndTime.Date"/>.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Date( DateTime dt) => new((uint)dt.Day, (uint) dt.Month, (uint) dt.Year);


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
        public static implicit operator Date( string strContent ) => From(strContent);


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{(uint) this.Day:D2}.{(uint) this.Month:D2}.{(uint) this.Year:D4}";


        /// <summary>
        /// Equalses the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public override bool Equals( object obj )
        {
            if( obj == null )
            {
                return false;
            }

            if( obj is not Date other )
            {
                return false;
            }

            if( this.Day.Equals(other.Day) == false )
            {
                return false;
            }

            if( this.Month.Equals(other.Month) == false )
            {
                return false;
            }

            if( this.Year.Equals(other.Year) == false )
            {
                return false;
            }

            return true;
        }
    }
}

