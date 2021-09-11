
// TODO: Warten bis wir einen Datentypen Meter haben !

//using System;

//using DoofesZeug.Attributes.Documentation;



//namespace DoofesZeug.Models.Science.Geographically.Base
//{
//    [Description("An simplified altitude.")]
//    // [Range()]
//    public class Altitude : EntityBase
//    {
//        public ulong MeterOverNN { get; set; }

//        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//        public Altitude()
//        {
//        }


//        public Altitude( ulong meterovernn ) => this.MeterOverNN = meterovernn;

//        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


//        /// <summary>
//        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
//        /// </summary>
//        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
//        /// <returns>
//        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
//        /// </returns>
//        public override bool Equals( object obj )
//        {
//            if( obj == null )
//            {
//                return false;
//            }

//            if( obj is not Altitude other )
//            {
//                return false;
//            }

//            if( this.MeterOverNN != other.MeterOverNN )
//            {
//                return false;
//            }

//            return true;
//        }


//        /// <summary>
//        /// Returns a hash code for this instance.
//        /// </summary>
//        /// <returns>
//        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
//        /// </returns>
//        public override int GetHashCode() => HashCode.Combine(this.MeterOverNN);
//    }
//}