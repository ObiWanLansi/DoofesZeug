using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Entities.Science.Base.Length;
using DoofesZeug.Entities.Science.Base.Weight;



namespace DoofesZeug.Entities.Specieses.Human
{
    [Description("An simplified person with an firstname, lastname, birthday and some other optional properties.")]
    //[Example("O:\\DoofesZeug\\DoofesZeug.UnitTests\\Src\\Functional\\Builder\\TestPersonBuilder.cs")]
    public class Person : Species
    {
        public FirstName FirstName { get; set; }

        public LastName LastName { get; set; }

        public Handedness? Handedness { get; set; }

        public BloodGroup? BloodGroup { get; set; }

        public WellKnownHairColor? HairColor { get; set; }

        public MajorReligion? Religion { get; set; }

        public WellKnownProfession? Profession { get; set; }

        public Centimeter AverageHeight { get; set; }

        public Kilogram AverageWeight { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public double? BMI => this.AverageHeight != null && this.AverageWeight != null
                    ? (float) this.AverageWeight.Value / (float) Math.Pow(( (float) this.AverageHeight.Value ) / 100, 2)
                    : null;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="string" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.LastName}, {this.FirstName} ({this.DateOfBirth})";


        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj ) => Equals(this, obj as Person);


        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => HashCode.Combine(base.GetHashCode(),
            HashCode.Combine(this.FirstName, this.LastName),
            HashCode.Combine(this.Handedness, this.BloodGroup),
            HashCode.Combine(this.HairColor, this.Religion),
            this.Profession, this.AverageHeight, this.AverageWeight);
    }
}
