using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("An simple link to an homepage.")]
    public sealed class Homepage : IdentifiableEntity
    {
        public Uri Url { get; set; }

        public InformationType? InformationType { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator Homepage( string url ) => new() { Url = new Uri(url) };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.Url.AbsoluteUri;


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(this.Url, this.InformationType);


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

            if( obj is not Homepage other )
            {
                return false;
            }

            if( this.Url != other.Url || this.InformationType != other.InformationType )
            {
                return false;
            }

            return true;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public override StringList Validate() => throw new NotImplementedException();
    }
}
