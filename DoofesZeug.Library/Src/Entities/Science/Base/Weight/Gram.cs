using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Weight
{
    [Description("This entity represents just a gram.")]
    [Link("https://en.wikipedia.org/wiki/Gram")]
    public class Gram : MetricValueBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gram"/> class.
        /// </summary>
        public Gram()
        {
            this.prefix = UnitPrefixes.Base;
            this.unit = "g";
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Gram"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Gram( double value ) : base(value)
        {
            this.prefix = UnitPrefixes.Base;
            this.unit = "g";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="double"/> to <see cref="Gram"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Gram( double value ) => new(value);
    }
}
