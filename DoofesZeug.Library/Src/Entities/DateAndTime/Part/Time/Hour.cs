using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.DateAndTime.Part.Time
{
    [Description("The hour (24h) of an time.")]
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
        /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Hour"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Hour( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Hour"/> to <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Hour value ) => value.Value;


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => this.Value < 0 || this.Value > 23 ? new StringList { $"The value '{this.Value}' for the hour is not acceptable!" } : ( new() );
    }
}
