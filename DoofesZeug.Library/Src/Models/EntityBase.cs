using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models
{
    [Description("The baseclass for all entites in this library.")]
    public abstract class EntityBase
    {
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override abstract bool Equals( object obj );
    }
}
