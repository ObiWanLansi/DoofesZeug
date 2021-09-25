using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.DateAndTime.Part.Date
{
    [Description("The week of an date in the year.")]
    public sealed class Week : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Week"/> class.
        /// </summary>
        public Week()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Week"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Week( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Week"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Week( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Week"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Week value ) => value.Value;
    }
}
