using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Entities.DateAndTime;



namespace DoofesZeug.Entities.Specieses
{
    [Description("An baseclass for all other entities who have an heart.")]
    public abstract class Species : IdentifiableEntity
    {
        public DateOfBirth DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj ) => Equals(this, obj as Species);


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.DateOfBirth, this.Gender);
    }
}
