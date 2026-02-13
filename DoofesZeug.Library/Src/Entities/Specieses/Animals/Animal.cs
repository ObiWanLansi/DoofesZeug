using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities.Specieses.Animals;

[Description("An simplified animal with an name and some other optional properties.")]
public class Animal : Species
{
    public WellKnownAnimal? AnimalSpecies { get; set; }

    public Name Name { get; set; }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString() => $"{this.Name}, {this.AnimalSpecies} ({this.DateOfBirth})";


    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public override bool Equals( object obj ) => Equals(this, obj as Animal);


    ///// <summary>
    ///// Returns a hash code for this instance.
    ///// </summary>
    ///// <returns>
    ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    ///// </returns>
    //public override int GetHashCode() => HashCode.Combine(base.GetHashCode(), this.AnimalSpecies, this.Name);


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate()
    {
        StringList sl = [.. base.Validate()];

        PropertyValidate(this, sl);

        return sl;
    }
}
