using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Models.Science.Base.Length
{
    [Description("This entity represents just a meter. For easier handling it is based on an double, so we can also set 5.2 m when needed.")]
    public class Meter : MetricValueBase<double>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Meter"/> class.
        /// </summary>
        public Meter()
        {
            this.prefix = UnitPrefixes.Base;
            this.unit = "m";
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Meter"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Meter( double value ) : base(value)
        {
            this.prefix = UnitPrefixes.Base;
            this.unit = "m";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int64"/> to <see cref="Meter"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Meter( double value ) => new(value);
    }
}
