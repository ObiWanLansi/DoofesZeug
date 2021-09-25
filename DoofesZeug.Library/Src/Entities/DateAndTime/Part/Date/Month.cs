using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.DateAndTime.Part.Date
{
    [Description("The month of an date.")]
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
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Month"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Month( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Month"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Month value ) => value.Value;


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => this.Value < 1 || this.Value > 12 ? new StringList { $"The value '{this.Value}' for the month is not acceptable!" } : ( new() );
    }
}
