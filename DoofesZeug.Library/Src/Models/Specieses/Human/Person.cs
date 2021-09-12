using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Pattern;
using DoofesZeug.Models.Specieses.Human.Professions;



namespace DoofesZeug.Models.Specieses.Human
{
    [Builder]
    [Description("An simplified person with an firstname, lastname, birthday and some other optional properties.")]
    [Example("O:\\DoofesZeug\\DoofesZeug.UnitTests\\Src\\Functional\\Builder\\TestPersonBuilder.cs")]
    public class Person : Species
    {
        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public Handedness? Handedness { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        public Profession Profession { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.LastName}, {this.FirstName} ({this.DateOfBirth})";


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj ) => Equals(this, obj as Person);


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.FirstName, this.LastName, this.Handedness, this.BloodGroup, this.Profession);
    }
}
