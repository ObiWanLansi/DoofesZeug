﻿using System.Globalization;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;
using DoofesZeug.Extensions;



namespace DoofesZeug.Entities.Science.Base;

[Description("An abstract base class for all other metric values.")]
public abstract class MetricValueBase : Entity //where T : unmanaged, IEquatable<T>
{
    // For floating point values it is important when we convert it to an string, that we have an point and not an comma as decimal seperator,
    // because so many other formats use an comma as value seperator.
    protected static readonly CultureInfo CULTUREINFO = new("en-US");

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// The unit prefix
    /// </summary>
    public UnitPrefix Prefix { get; protected set; }


    /// <summary>
    /// The unit (m for meter, g for gramm, ...).
    /// </summary>
    public string Unit { get; protected set; }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Must have an public setter for JSON converting :-(
    public double Value { get;  set; }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Initializes a new instance of the <see cref="MetricValueBase{T}"/> class.
    /// </summary>
    protected MetricValueBase()
    {
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="MetricValueBase{T}"/> class.
    /// </summary>
    /// <param name="value">The value.</param>
    protected MetricValueBase( double value ) => this.Value = value;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    ///// <summary>
    ///// Performs an implicit conversion from <see cref="DoofesZeug.Entities.Science.Base.MetricValueBase{T}"/> to <see cref="T"/>.
    ///// </summary>
    ///// <param name="mtb">The MTB.</param>
    ///// <returns>
    ///// The result of the conversion.
    ///// </returns>
    //public static explicit operator T( MetricValueBase<T> mtb ) => mtb.Value;
    public static explicit operator double( MetricValueBase mvb ) => mvb.Value;


    /// <summary>
    /// Logicallies the equals.
    /// </summary>
    /// <param name="other">The other.</param>
    /// <returns></returns>
    public bool LogicallyEquals( MetricValueBase other )
    {
        if( other == null )
        {
            return false;
        }

        if( this.Unit.Equals(other.Unit) == false )
        {
            return false;
        }

        double thisvalue = this.Value * this.Prefix.Factor;
        double othervalue = other.Value * other.Prefix.Factor;

        return thisvalue == othervalue;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.Prefix != null && this.Unit.IsNotEmpty()
            ? string.Format(CULTUREINFO, "{0} {1}{2}", this.Value, this.Prefix.Symbol, this.Unit)
            : string.Format(CULTUREINFO, "{0}", this.Value);
    }


    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals( object obj )
    {
        if( obj == null )
        {
            return false;
        }

        if( obj is not MetricValueBase other )
        {
            return false;
        }

        if( this.Prefix.Equals(other.Prefix) == false )
        {
            return false;
        }

        if( this.Unit.Equals(other.Unit) == false )
        {
            return false;
        }

        if( this.Value.Equals(other.Value) == false )
        {
            return false;
        }

        return true;
    }


    ///// <summary>
    ///// Returns a hash code for this instance.
    ///// </summary>
    ///// <returns>
    ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    ///// </returns>
    //public override int GetHashCode() => this.Value.GetHashCode();
}
