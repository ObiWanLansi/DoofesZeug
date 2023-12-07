using System;



namespace DoofesZeug.Extensions;

public static class EnumerationExtension
{
    /// <summary>
    /// Determines whether the specified e object is set.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eObject">The e object.</param>
    /// <param name="tValue">The t value.</param>
    /// <returns>
    ///   <c>true</c> if the specified e object is set; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsSet<T>( this Enum eObject, T tValue )
    {
        // Der einfachste Weg, einfach alles in Integer wandeln und testen.
        int iObject = Convert.ToInt32(eObject);
        int iValue = Convert.ToInt32(tValue);

        return ( iObject & iValue ) == iValue;
    }


    /// <summary>
    /// Adds the specified t value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eObject">The e object.</param>
    /// <param name="tValue">The t value.</param>
    /// <returns></returns>
    public static T Add<T>( this Enum eObject, T tValue )
    {
        // Der einfachste Weg, einfach alles in Integer wandeln und addieren.
        int iObject = Convert.ToInt32(eObject);
        int iValue = Convert.ToInt32(tValue);

        int iResult = iObject | iValue;

        return (T) Enum.ToObject(typeof(T), iResult);
    }


    /// <summary>
    /// Removes the specified t value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eObject">The e object.</param>
    /// <param name="tValue">The t value.</param>
    /// <returns></returns>
    public static T Remove<T>( this Enum eObject, T tValue )
    {
        // Der einfachste Weg, einfach alles in Integer wandeln und addieren.
        int iObject = Convert.ToInt32(eObject);
        int iValue = Convert.ToInt32(tValue);

        int iResult = iObject ^ iValue;

        return (T) Enum.ToObject(typeof(T), iResult);
    }
}
