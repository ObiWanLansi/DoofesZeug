using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



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


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => this.Value < 1 || this.Value > 52 ? new StringList { $"The value '{this.Value}' for the week is not acceptable!" } : ( new() );
    }
}
