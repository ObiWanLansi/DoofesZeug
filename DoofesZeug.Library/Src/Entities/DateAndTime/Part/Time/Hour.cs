﻿using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.DateAndTime.Part.Time;

[Description("The hour (24h) of an time.")]
public sealed class Hour : DateTimePart, IComparable<Hour>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Hour"/> class.
    /// </summary>
    public Hour()
    {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Hour"/> class.
    /// </summary>
    /// <param name="iInitalValue">The i inital value.</param>
    public Hour( uint iInitalValue ) : base(iInitalValue)
    {
    }


    /// <summary>
    /// Performs an implicit conversion from <see cref="uint"/> to <see cref="Hour"/>.
    /// </summary>
    /// <param name="iValue">The i value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator Hour( uint iValue ) => new(iValue);


    /// <summary>
    /// Performs an implicit conversion from <see cref="Hour"/> to <see cref="uint"/>.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>
    /// The result of the conversion.
    /// </returns>
    public static implicit operator uint( Hour value ) => value.Value;


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate() => this.Value < 0 || this.Value > 23 ? new StringList { $"The value '{this.Value}' for the hour is not acceptable!" } : ( new() );


    /// <summary>
    /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">An object to compare with this instance.</param>
    /// <returns>
    /// A value that indicates the relative order of the objects being compared. The return value has these meanings:
    /// <list type="table"><listheader><term> Value</term><description> Meaning</description></listheader><item><term> Less than zero</term><description> This instance precedes <paramref name="other" /> in the sort order.</description></item><item><term> Zero</term><description> This instance occurs in the same position in the sort order as <paramref name="other" />.</description></item><item><term> Greater than zero</term><description> This instance follows <paramref name="other" /> in the sort order.</description></item></list>
    /// </returns>
    public int CompareTo( Hour other ) => this.Value.CompareTo(other.Value);
}
