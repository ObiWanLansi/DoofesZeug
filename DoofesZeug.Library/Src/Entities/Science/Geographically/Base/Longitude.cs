using System.Globalization;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Entities.Science.Geographically.Base
{
    [Description("An simplified longitude (WGS84).")]
    [Range(-180,180)]
    public class Longitude : Entity
    {
        protected static readonly CultureInfo CULTUREINFO = new("en-US");

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public double Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Longitude"/> class.
        /// </summary>
        public Longitude()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Longitude"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Longitude( double value ) => this.Value = value;


        /// <summary>
        /// Initializes a new instance of the <see cref="Longitude"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Longitude( string value ) => this.Value = double.Parse(value, CULTUREINFO);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => string.Format(CULTUREINFO, "{0}", this.Value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Double"/> to <see cref="Longitude"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Longitude( double value ) => new(value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


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

            if( obj is not Longitude other )
            {
                return false;
            }

            if( this.Value != other.Value )
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