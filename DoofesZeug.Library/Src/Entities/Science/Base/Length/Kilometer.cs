using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Length;

[Description("This entity represents just a kilometer.")]
[Link("https://en.wikipedia.org/wiki/Metre")]
public class Kilometer : MetricValueBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Kilometer"/> class.
    /// </summary>
    public Kilometer()
    {
        this.Prefix = UnitPrefixes.Kilo;
        this.Unit = "m";
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Kilometer"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Kilometer( double value ) : base(value)
    {
        this.Prefix = UnitPrefixes.Kilo;
        this.Unit = "m";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="Kilometer"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Kilometer( double value ) => new(value);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Meter"/> to <see cref="Kilometer"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Kilometer( Meter value ) => new(value.Value / 1000);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 ? new StringList { $"The value '{this.Value}' for the kilometer is not acceptable!" } : ( new() );
}
