using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Time
{
    [Description("The hours of an time.")]
    [Range(0, 23)]
    public sealed class Hour : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Hour"/> class.
        /// </summary>
        public Hour()
        { 
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Hour"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Hour( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="Hour"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Hour( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Hour"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Hour value ) => value.Value;
    }
}
