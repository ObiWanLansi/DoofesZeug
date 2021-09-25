using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.DateAndTime.Part.Date
{
    [Description("The year of an date.")]
    public sealed class Year : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Year"/> class.
        /// </summary>
        public Year()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Year"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Year( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Year"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Year( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Year"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Year value ) => value.Value;
    }
}
