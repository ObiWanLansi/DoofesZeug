using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Models.Science.Base.Length
{
    [Description("This entity represents just a kilometer.")]
    public class Kilometer : Meter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Kilometer"/> class.
        /// </summary>
        public Kilometer()
        {
            this.prefix = UnitPrefixes.Kilo;
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Kilometer"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Kilometer( double value ) : base(value)
        {
            this.prefix = UnitPrefixes.Kilo;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Double"/> to <see cref="Kilometer"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Kilometer( double value ) => new(value);
    }
}
