using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Specieses.Human.Professions
{
    [Description("The baseclass for all other professions.")]
    public abstract class Profession : IdentifiableEntity
    {
        public WellKnownProfession? WellKnownProfessionType { get; private set; }

        public Date Since { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="Profession"/> class.
        /// </summary>
        /// <param name="wkp">The WKP.</param>
        protected Profession( WellKnownProfession wkp ) => this.WellKnownProfessionType = wkp;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.WellKnownProfessionType} ({this.Since})";


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

            if( obj is not Profession other )
            {
                return false;
            }


            if( this.WellKnownProfessionType != other.WellKnownProfessionType )
            {
                return false;
            }

            if( this.Since.Equals(other.Since) == false )
            {
                return false;
            }

            return true;
            //            return obj is not Profession other
            //? false
            //: this.WellKnownProfessionType.Equals(other.WellKnownProfessionType) == false ? false : this.Since.Equals(other.Since) != false;
        }


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.WellKnownProfessionType, this.Since);
    }
}
