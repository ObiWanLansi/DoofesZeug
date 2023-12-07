using System.Reflection;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Entities;

[Description("The baseclass for all entites in this library.")]
public abstract class Entity
{
    /// <summary>
    /// Determines whether the specified <see cref="object" />, is equal to this instance.
    /// </summary>
    /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
    /// <returns>
    ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
    /// </returns>
    public abstract override bool Equals( object obj );

    ///// <summary>
    ///// Returns a hash code for this instance.
    ///// </summary>
    ///// <returns>
    ///// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
    ///// </returns>
    //public override abstract int GetHashCode();


    /// <summary>
    /// Validates this instance.
    /// </summary>
    /// <returns></returns>
    public abstract StringList Validate();

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    protected static void PropertyValidate<T>( T instance, StringList sl ) where T : Entity
    {
        if( instance == null )
        {
            sl.Add("The instance is null!");
            return;
        }

        // Now from the declared properties
        foreach( PropertyInfo pi in instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly) )
        {
            if( pi.CanWrite == false )
            {
                continue;
            }

            if( pi.PropertyType.IsAssignableTo(typeof(Entity)) )
            {
                Entity e = (Entity) pi.GetValue(instance);

                if( e != null )
                {
                    sl.AddRange(e.Validate());
                }
                else
                {
                    sl.Add($"The property {pi.Name} is null!");
                }
            }
            else
            {
                if( pi.GetValue(instance) == null )
                {
                    sl.Add($"The property {pi.Name} is null!");
                }
            }
        }
    }


    /// <summary>
    /// Equalses the specified one and two.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="one">The one.</param>
    /// <param name="two">The two.</param>
    /// <returns></returns>
    protected static bool Equals<T>( T one, T two )
    {
        if( one == null && two == null )
        {
            return true;
        }

        if( one == null && two != null )
        {
            return false;
        }

        if( one != null && two == null )
        {
            return false;
        }

        //-----------------------------------------------------------------

        //foreach( PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.DeclaredOnly) )
        foreach( PropertyInfo pi in typeof(T).GetProperties(BindingFlags.Instance) )
        {
            object oOne = pi.GetValue(one);
            object oTwo = pi.GetValue(two);

            if( oOne == null && oTwo != null )
            {
                return false;
            }

            if( oOne != null && oTwo == null )
            {
                return false;
            }

            if( oOne != null && oTwo != null )
            {
                if( oOne.Equals(oTwo) == false )
                {
                    return false;
                }
            }
        }

        //-----------------------------------------------------------------

        return true;
    }
}
