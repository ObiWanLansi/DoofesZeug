using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Length;

[Description("This entity represents just a meter.")]
[Link("https://en.wikipedia.org/wiki/Metre")]
public class Meter : MetricValueBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Meter"/> class.
    /// </summary>
    public Meter()
    {
        this.Prefix = UnitPrefixes.Base;
        this.Unit = "m";
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Meter"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Meter( double value ) : base(value)
    {
        this.Prefix = UnitPrefixes.Base;
        this.Unit = "m";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="Meter"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Meter( double value ) => new(value);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Kilometer"/> to <see cref="Meter"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Meter( Kilometer value ) => new(value.Value * 1000);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Centimeter"/> to <see cref="Meter"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Meter( Centimeter value ) => new(value.Value / 100);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 ? new StringList { $"The value '{this.Value}' for the meter is not acceptable!" } : ( new() );
}
