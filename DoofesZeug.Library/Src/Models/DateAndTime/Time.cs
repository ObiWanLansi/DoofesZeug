using System;

using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.DateAndTime.Part.Time;



namespace DoofesZeug.Models.DateAndTime
{
    [Builder]
    public class Time : EntityBase
    {
        /// <summary>
        /// Gets the hour.
        /// </summary>
        /// <value>
        /// The hour.
        /// </value>
        public Hour Hour { get; set; }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        /// <value>
        /// The minute.
        /// </value>
        public Minute Minute { get; set; }

        /// <summary>
        /// Gets the second.
        /// </summary>
        /// <value>
        /// The second.
        /// </value>
        public Second Second { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static readonly Time MIN = new((uint) 00, 00, 00);

        public static readonly Time MAX = new((uint) 23, 59, 59);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Time()
        {
        }


        public Time( Time time )
        {
            this.Hour = time.Hour;
            this.Minute = time.Minute;
            this.Second = time.Second;
        }


        public Time( DateTime dt )
        {
            this.Hour = (uint) dt.Hour;
            this.Minute = (uint) dt.Minute;
            this.Second = (uint) dt.Second;
        }


        public Time( uint hour, uint minute, uint second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }


        public Time( Hour hour, Minute minute, Second second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.ValueTuple{Hour, Minute, Second}"/> to <see cref="Time"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Time( (Hour hour, Minute minute, Second second) value ) => new(value.hour, value.minute, value.second);


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="Time"/>.
        /// </summary>
        /// <param name="strContent">The string time.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Time( string strContent )
        {
            // 0123456789
            // 15:10:42

            if( strContent.Length != 8 )
            {
                throw new ArgumentException("The length of the time ist not eight characters.", nameof(strContent));
            }

            if( strContent [2] == ':' == false || strContent [5] == ':' == false )
            {
                throw new ArgumentException("The time have not the right format 'hh.mm.ss'.", nameof(strContent));
            }

            uint hour = Convert.ToUInt32(strContent.Substring(0, 2));
            uint minute = Convert.ToUInt32(strContent.Substring(3, 2));
            uint second = Convert.ToUInt32(strContent.Substring(6, 2));

            return new Time(hour, minute, second);
        }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{(uint) this.Hour:D2}:{(uint) this.Minute:D2}:{(uint) this.Second:D2}";
    }
}

