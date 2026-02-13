using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.DateAndTime.Part.Time;

[Description("The seconds of an time.")]
public sealed class Second : DateTimePart, IComparable<Second>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Second"/> class.
    /// </summary>
    public Second()
    {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Second"/> class.
    /// </summary>
    /// <param name="iInitalValue">The i inital value.</param>
    public Second( uint iInitalValue ) : base(iInitalValue)
    {
    }


    /// <summary>
    /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Second"/>.
    /// </summary>
    /// <param name="iValue">The i value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Second( uint iValue ) => new(iValue);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Second"/> to <see cref="uint"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator uint( Second value ) => value.Value;


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 || this.Value > 59 ? [$"The value '{this.Value}' for the second is not acceptable!"] : ( [] );


    /// <summary>
    /// Compares to.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns></returns>
    public int CompareTo( Second other ) => this.Value.CompareTo(other.Value);
}
