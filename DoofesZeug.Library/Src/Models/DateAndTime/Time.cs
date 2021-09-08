﻿using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Extensions;
using DoofesZeug.Models.DateAndTime.Part.Time;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An time entity with hours, minutes and the seconds (12:34:56).")]
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


        /// <summary>
        /// The minimum
        /// </summary>
        public static readonly Time Min = new((uint) 00, 00, 00);

        /// <summary>
        /// The maximum
        /// </summary>
        public static readonly Time Max = new((uint) 23, 59, 59);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        public Time()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="time">The time.</param>
        public Time( Time time )
        {
            this.Hour = time.Hour;
            this.Minute = time.Minute;
            this.Second = time.Second;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public Time( DateTime dt )
        {
            this.Hour = (uint) dt.Hour;
            this.Minute = (uint) dt.Minute;
            this.Second = (uint) dt.Second;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public Time( uint hour, uint minute, uint second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="hour">The hour.</param>
        /// <param name="minute">The minute.</param>
        /// <param name="second">The second.</param>
        public Time( Hour hour, Minute minute, Second second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the specified string content.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">
        /// The length of the time ist not eight characters., nameof(strContent)
        /// or
        /// The length of the time ist not eight characters., nameof(strContent)
        /// </exception>
        public static Time From( string strContent )
        {
            // 0123456789
            // 15:10:42

            if( strContent.IsEmpty() || strContent.EqualsIgnoreCase("null") )
            {
                return null;
            }

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
        public static implicit operator Time( string strContent ) => From(strContent);


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{(uint) this.Hour:D2}:{(uint) this.Minute:D2}:{(uint) this.Second:D2}";


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

            if( obj is not Time other )
            {
                return false;
            }

            if( this.Hour.Equals(other.Hour)==false)
            {
                return false;
            }

            if( this.Minute.Equals(other.Minute) == false )
            {
                return false;
            }

            if( this.Second.Equals(other.Second) == false )
            {
                return false;
            }

            return true;
        }
    }
}

