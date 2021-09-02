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


        public Time()
        {
        }


        public Time( DateTime dt )
        {
            this.Hour = dt.Hour;
            this.Minute = dt.Minute;
            this.Second = dt.Second;
        }


        public Time( Hour hour, Minute minute, Second second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.Hour:D2}:{this.Minute:D2}:{this.Second:D2}";
    }
}

