using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Entities.DateAndTime.Part.Time
{
    [Description("The seconds of an time.")]
    [Range(0, 59)]
    public sealed class Second : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Second"/> class.
        /// </summary>
        public Second()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Second"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Second( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="Second"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Second( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Second"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Second value ) => value.Value;
    }
}
