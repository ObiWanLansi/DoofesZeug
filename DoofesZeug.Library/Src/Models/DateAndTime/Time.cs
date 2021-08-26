using System;



namespace DoofesZeug.Models.DateAndTime
{
    public class Time
    {
        /// <summary>
        /// Gets the hour.
        /// </summary>
        /// <value>
        /// The hour.
        /// </value>
        public int Hour { get; init; }

        /// <summary>
        /// Gets the minute.
        /// </summary>
        /// <value>
        /// The minute.
        /// </value>
        public int Minute { get; init; }

        /// <summary>
        /// Gets the second.
        /// </summary>
        /// <value>
        /// The second.
        /// </value>
        public int Second { get; init; }

        /// <summary>
        /// Gets the millisecond.
        /// </summary>
        /// <value>
        /// The millisecond.
        /// </value>
        public int Millisecond { get; init; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Time"/> class.
        /// </summary>
        /// <param name="dt">The dt.</param>
        public Time( DateTime dt )
        {
            this.Hour = dt.Hour;
            this.Minute = dt.Minute;
            this.Second = dt.Second;
            this.Millisecond = dt.Millisecond;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.Hour:D2}:{this.Minute:D2}:{this.Second:D2}.{this.Millisecond:D3}";
    }
}

