using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses
{
    [Description("An generic name for any species.")]
    public class Name : EntityBase
    {
        public string Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Name() { }


        public Name( string value ) => this.Value = value;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static implicit operator Name( string value ) => new(value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => this.Value;


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

            if( obj is not Name other )
            {
                return false;
            }

            if( this.Value != other.Value )
            {
                return false;
            }

            return true;

            //return obj == null ? false : obj is not Name other ? false : this.Value == other.Value;
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
