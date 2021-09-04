using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Description("The month of an date.")]
    [Range(1, 12)]
    public sealed class Month : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Month"/> class.
        /// </summary>
        public Month()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Month"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Month( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="Month"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Month( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Month"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Month value ) => value.Value;
    }
}
