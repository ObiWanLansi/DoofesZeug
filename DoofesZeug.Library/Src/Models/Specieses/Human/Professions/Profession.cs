using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Models.DateAndTime;



namespace DoofesZeug.Models.Specieses.Human.Professions
{
    [Description("The baseclass for all other professions.")]
    public abstract class Profession : IdentifiableEntity
    {
        public WellKnownProfession WellKnownProfessionType { get; private set; }

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
        public override bool Equals( object obj ) => base.Equals(obj) != false && ( obj is not Profession other
                ? false
                : this.WellKnownProfessionType.Equals(other.WellKnownProfessionType) == false ? false : this.Since.Equals(other.Since) != false );
    }
}
