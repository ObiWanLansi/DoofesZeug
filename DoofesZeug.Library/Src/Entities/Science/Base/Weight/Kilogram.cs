using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Weight;

[Description("This entity represents just a kilogram.")]
[Link("https://en.wikipedia.org/wiki/Gram")]
public class Kilogram : MetricValueBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Kilogram"/> class.
    /// </summary>
    public Kilogram()
    {
        this.Prefix = UnitPrefixes.Kilo;
        this.Unit = "g";
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Kilogram"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Kilogram( double value ) : base(value)
    {
        this.Prefix = UnitPrefixes.Kilo;
        this.Unit = "g";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="Kilogram"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Kilogram( double value ) => new(value);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 ? [$"The value '{this.Value}' for the kilogram is not acceptable!"] : ( [] );
}
