using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Entities.DateAndTime.Part.Time
{
    [Description("The minutes of an time.")]
    [Range(0, 59)]
    public sealed class Minute : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Minute"/> class.
        /// </summary>
        public Minute()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Minute"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Minute( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Minute"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Minute( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Minute"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Minute value ) => value.Value;
    }
}
