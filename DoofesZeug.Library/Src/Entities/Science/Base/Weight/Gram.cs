using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Weight
{
    [Description("This entity represents just a gram.")]
    public class Gram : MetricValueBase<double>
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
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Gram"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Gram( double value ) => new(value);

    }
}
