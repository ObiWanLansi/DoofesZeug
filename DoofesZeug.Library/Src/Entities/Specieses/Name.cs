using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;
using DoofesZeug.Extensions;



namespace DoofesZeug.Entities.Specieses;

[Description("An generic name for any species.")]
public class Name : Entity
{
    public string Value { get; set; }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public Name() { }


    public Name( string value ) => this.Value = value;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    public static implicit operator Name( string value ) => new(value);


    public static explicit operator string( Name value ) => value.Value;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Converts to string.
    /// </summary>
    /// <returns>
    /// A <see cref="string" /> that represents this instance.
    /// </returns>
    public override string ToString() => this.Value;


    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
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


    ///// <summary>
    ///// Returns a hash code for this instance.
    ///// </summary>
    ///// <returns>
    ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    ///// </returns>
    //public override int GetHashCode() => this.Value.GetHashCode();


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public override StringList Validate()
    {
        if( this.Value == null )
        {
            return new StringList { "The name is null!" };
        }

        if( this.Value.Length < 3 )
        {
            return new StringList { "The length of the name is less than 3 characters!" };
        }

        if( this.Value.Length > 32 )
        {
            return new StringList { "The length of the name is more than 32 characters!" };
        }

        if( this.Value.ContainsNonLetterCharacters() )
        {
            return new StringList { "The name contains non letter characters!" };
        }

        return new();
    }
}
