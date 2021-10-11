using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.Science.Geographically.Coordinates
{
    [Description("An simplified altitude in meter over nn.")]
    public class Altitude : Entity
    {
        private readonly ulong MeterOverNN;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Altitude"/> class.
        /// </summary>
        public Altitude()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Altitude"/> class.
        /// </summary>
        /// <param name="meterovernn">The meterovernn.</param>
        public Altitude( ulong meterovernn ) => this.MeterOverNN = meterovernn;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{this.MeterOverNN}";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt64"/> to <see cref="Altitude"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Altitude( ulong value ) => new(value);


        /// <summary>
        /// Performs an explicit conversion from <see cref="Altitude"/> to <see cref="System.UInt64"/>.
        /// </summary>
        /// <param name="v">The v.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static explicit operator ulong( Altitude v ) => v.MeterOverNN;

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

            if( obj is not Altitude other )
            {
                return false;
            }

            if( this.MeterOverNN != other.MeterOverNN )
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
        //public override int GetHashCode() => HashCode.Combine(this.MeterOverNN);


        /// <summary>
        /// Validates this instance.
        /// </summary>
        /// <returns></returns>
        public override StringList Validate() => throw new NotImplementedException();
    }
}