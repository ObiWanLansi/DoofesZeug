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
        public override bool Equals( object obj ) => obj == null ? false : obj is not Name other ? false : this.Value == other.Value;
    }
}
