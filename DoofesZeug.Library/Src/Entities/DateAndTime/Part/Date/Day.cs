using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.DateAndTime.Part.Date
{
    [Description("The day of an date.")]
    public sealed class Day : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Day"/> class.
        /// </summary>
        public Day()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Day"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Day( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Day"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Day( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Day"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Day value ) => value.Value;


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => this.Value < 1 || this.Value > 31 ? new StringList { $"The value '{this.Value}' for the day is not acceptable!" } : ( new() );
    }
}
