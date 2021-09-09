using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Science.Geographically.Base
{
    [Description("An simplified longitude (WGS84).")]
    // [Range()]
    public class Longitude : EntityBase
    {
        public double Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Longitude()
        {
        }


        public Longitude( double value ) => this.Value = value;

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
        public override int GetHashCode() => HashCode.Combine(this.Value);
    }
}