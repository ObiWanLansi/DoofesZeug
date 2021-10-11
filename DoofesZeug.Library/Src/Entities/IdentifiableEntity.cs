using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities
{
    [Description("An baseclass for all other entities who should have an unique id as Guid.")]
    public abstract class IdentifiableEntity : Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj ) => obj is IdentifiableEntity other && this.Id.Equals(other.Id) != false ;


        ///// <summary>
        ///// Returns a hash code for this instance.
        ///// </summary>
        ///// <returns>
        ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        ///// </returns>
        //public override int GetHashCode() => this.Id.GetHashCode();
    }
}
