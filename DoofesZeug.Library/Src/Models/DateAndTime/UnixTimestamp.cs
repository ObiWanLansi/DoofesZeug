using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An unix timestamp (seconds since 01.01.1970).")]
    public sealed class UnixTimestamp : EntityBase
    {
        /// <summary>
        /// The unix timestamp
        /// </summary>
        private readonly ulong lUnixTimestamp = 0;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Prevents a default instance of the <see cref="UnixTimestamp"/> class from being created.
        /// </summary>
        public UnixTimestamp() //: this(DateTime.Now)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnixTimestamp"/> class.
        /// </summary>
        /// <param name="ut">The ut.</param>
        /// <exception cref="ArgumentNullException">ut</exception>
        public UnixTimestamp( UnixTimestamp ut )
        {
            if( ut == null )
            {
                throw new ArgumentNullException(nameof(ut));
            }

            this.lUnixTimestamp = ut.lUnixTimestamp;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnixTimestamp"/> class.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <exception cref="ArgumentNullException">dt</exception>
        public UnixTimestamp( DateTime dt )
        {
            DateTime dtUnix = new(1970, 1, 1, 0, 0, 0, dt.Kind);

            this.lUnixTimestamp = (ulong) ( dt - dtUnix ).TotalSeconds;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="UnixTimestamp"/> to <see cref="ulong"/>.
        /// </summary>
        /// <param name="ut">The ut.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ulong( UnixTimestamp ut ) => ut.lUnixTimestamp;


        /// <summary>
        /// Performs an implicit conversion from <see cref="UnixTimestamp"/> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="ut">The ut.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator DateTime( UnixTimestamp ut )
        {
            DateTime dtUnix = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Local);

            return dtUnix.AddSeconds(ut.lUnixTimestamp);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the specified dt.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static UnixTimestamp From( DateTime dt ) => new(dt);


        /// <summary>
        /// Nows this instance.
        /// </summary>
        /// <returns></returns>
        public static UnixTimestamp Now() => new(DateTime.Now);


        /// <summary>
        /// Empties this instance.
        /// </summary>
        /// <returns></returns>
        public static UnixTimestamp Empty() => new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.lUnixTimestamp}";
    }
}
