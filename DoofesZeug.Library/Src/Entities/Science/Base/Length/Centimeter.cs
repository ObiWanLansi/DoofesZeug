using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Length;

[Description("This entity represents just a centimeter.")]
[Link("https://en.wikipedia.org/wiki/Metre")]
public class Centimeter : MetricValueBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Centimeter"/> class.
    /// </summary>
    public Centimeter()
    {
        this.Prefix = UnitPrefixes.Centi;
        this.Unit = "m";
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Centimeter"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Centimeter( double value ) : base(value)
    {
        this.Prefix = UnitPrefixes.Centi;
        this.Unit = "m";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="Centimeter"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Centimeter( double value ) => new(value);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Meter"/> to <see cref="Centimeter"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Centimeter( Meter value ) => new(value.Value * 100);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 ? [$"The value '{this.Value}' for the centimeter is not acceptable!"] : ( [] );
}
