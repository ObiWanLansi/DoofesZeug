﻿using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Datatypes.Misc;



namespace DoofesZeug.Entities.Science.Base.Weight;

[Description("This entity represents just a milligram.")]
[Link("https://en.wikipedia.org/wiki/Gram")]
public class Milligram : MetricValueBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Milligram"/> class.
    /// </summary>
    public Milligram()
    {
        this.Prefix = UnitPrefixes.Milli;
        this.Unit = "g";
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Milligram"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    public Milligram( double value ) : base(value)
    {
        this.Prefix = UnitPrefixes.Milli;
        this.Unit = "g";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Performs an implicit conversion from <see cref="double"/> to <see cref="Milligram"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Milligram( double value ) => new(value);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 ? new StringList { $"The value '{this.Value}' for the milligram is not acceptable!" } : ( new() );
}
