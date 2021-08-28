using System;

using DoofesZeug.Attributes;



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
        public int Hour { get; set; }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        /// <value>
        /// The minute.
        /// </value>
        public int Minute { get; set; }

        /// <summary>
        /// Gets the second.
        /// </summary>
        /// <value>
        /// The second.
        /// </value>
        public int Second { get; set; }

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


        public Time( int hour, int minute, int second )
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static public Time From( int hour, int minute, int second ) => new(hour, minute, second);

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

