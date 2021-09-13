using System;
using System.Globalization;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Misc;
using DoofesZeug.Extensions;



namespace DoofesZeug.Models.Science.Base
{
    [Description("An abstract base class for all other metric values.")]
    public abstract class MetricValueBase<T> : Entity where T : unmanaged, IEquatable<T>
    {
        // For floating point values it is important when we convert it to an string, that we have an point and not an comma as decimal seperator,
        // because so many other formats use an comma as value seperator.
        protected static readonly CultureInfo CULTUREINFO = new("en-US");

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// The unit prefix
        /// </summary>
        protected UnitPrefix prefix;


        /// <summary>
        /// The unit (m for meter, g for gramm, ...).
        /// </summary>
        protected string unit;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public T Value { get; set; }

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
        protected MetricValueBase( T value ) => this.Value = value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="DoofesZeug.Models.Science.Base.MetricValueBase{T}"/> to <see cref="T"/>.
        /// </summary>
        /// <param name="mtb">The MTB.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator T( MetricValueBase<T> mtb ) => mtb.Value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if( prefix != null && unit.IsNotEmpty() )
            {
                return string.Format(CULTUREINFO, "{0} {1}{2}", this.Value, prefix.Symbol, unit);
            }

            return string.Format(CULTUREINFO, "{0}", this.Value);
        }


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if( obj == null )
            {
                return false;
            }

            if( obj is not MetricValueBase<T> other )
            {
                return false;
            }

            if( this.prefix.Equals(other.prefix) == false )
            {
                return false;
            }

            if( this.unit.Equals(other.unit) == false )
            {
                return false;
            }

            if( this.Value.Equals(other.Value) == false )
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => this.Value.GetHashCode();
    }
}
