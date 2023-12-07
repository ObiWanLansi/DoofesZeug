using System;
using System.Collections.Generic;
using System.Text;



namespace DoofesZeug.Extensions;

/// <summary>
/// Eine Erweiterungsklasse für System.Random .
/// </summary>
public static class RandomExtension
{
    /// <summary>
    /// Nexts the int.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns></returns>
    public static int NextInt( this Random r ) => r.Next();


    /// <summary>
    /// Nexts the u int.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns></returns>
    public static uint NextUInt( this Random r ) => (uint) r.Next();


    /// <summary>
    /// Nexts the bool.
    /// </summary>
    /// <param name="r">The current random object</param>
    /// <returns></returns>
    public static bool NextBool( this Random r ) => ( r.Next() % 2 ) != 0;


    ///// <summary>
    ///// Nexts the enum.
    ///// </summary>
    ///// <param name="r">The r.</param>
    ///// <param name="tEnum">The t enum.</param>
    ///// <returns></returns>
    //public static int NextEnum( this Random r, Type tEnum )
    //{
    //    if( tEnum.IsEnum == false )
    //    {
    //        return 0;
    //    }

    //    Array aValues = Enum.GetValues(tEnum);

    //    if( tEnum.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0 )
    //    {
    //        int iValue = 0;

    //        for( int iCounter = 0 ; iCounter < r.Next(aValues.Length) ; iCounter++ )
    //        {
    //            iValue |= (int) aValues.GetValue(r.Next(aValues.Length));
    //        }

    //        return (int) Enum.ToObject(tEnum, iValue);
    //    }

    //    return (int) aValues.GetValue(r.Next(aValues.Length));
    //}


    /// <summary>
    /// Liefert einen zufälligen Enumeration Wert zu einer Enumeration zurück.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="r">The current random object</param>
    /// <returns></returns>
    public static T NextEnum<T>( this Random r )
    {
        Type tEnum = typeof(T);

        if( tEnum.IsEnum == false )
        {
            return default;
        }

        Array aValues = Enum.GetValues(tEnum);

        if( tEnum.GetCustomAttributes(typeof(FlagsAttribute), false).Length > 0 )
        {
            int iValue = 0;

            for( int iCounter = 0 ; iCounter < r.Next(aValues.Length) ; iCounter++ )
            {
                iValue |= (int) aValues.GetValue(r.Next(aValues.Length));
            }

            return (T) Enum.ToObject(tEnum, iValue > 0 ? iValue : 1);
        }

        return (T) aValues.GetValue(r.Next(aValues.Length));
    }


    /// <summary>
    /// Nexts the string.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="iMinLength">Length of the i min.</param>
    /// <param name="iMaxLength">Length of the i max.</param>
    /// <returns></returns>
    public static string NextString( this Random r, int iMinLength, int iMaxLength )
    {
        // Achtung: Hier MaxLength inklusive ...
        int iLength = r.Next(iMinLength, iMaxLength + 1);

        StringBuilder sb = new(iLength);

        for( int iCounter = 0 ; iCounter < iLength ; iCounter++ )
        {
            sb.Append((char) r.Next(65, 91));
        }

        return sb.ToString();
    }


    /// <summary>
    /// Nexts the salt.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="iSaltLength">Length of the i salt.</param>
    /// <returns></returns>
    public static string NextSalt( this Random r, int iSaltLength = 5 )
    {
        StringBuilder sb = new(iSaltLength);

        for( int iCounter = 0 ; iCounter < iSaltLength ; iCounter++ )
        {
            sb.Append((char) r.Next(32, 255));
        }

        return sb.ToString();
    }


    /// <summary>
    /// Nexts the long.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns></returns>
    public static long NextLong( this Random r ) => ( ( (long) r.NextInt() ) << 32 ) + r.NextInt();


    /// <summary>
    /// Nexts the u long.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns></returns>
    public static ulong NextULong( this Random r ) => ( (ulong) r.NextInt() << 32 ) + (ulong) r.NextInt();


    /// <summary>
    /// Nexts the date time.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="dtMin">The dt minimum.</param>
    /// <param name="dtMax">The dt maximum.</param>
    /// <param name="dtk">The DTK.</param>
    /// <returns></returns>
    public static DateTime NextDateTime( this Random r, DateTime dtMin, DateTime dtMax, DateTimeKind dtk = DateTimeKind.Local ) => new(( r.NextLong() % ( dtMax.Ticks - dtMin.Ticks ) ) + dtMin.Ticks, dtk);


    /// <summary>
    /// Nexts the date time.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="dtk">The DTK.</param>
    /// <returns></returns>
    public static DateTime NextDateTime( this Random r, DateTimeKind dtk = DateTimeKind.Local ) => NextDateTime(r, DateTime.MinValue, DateTime.MaxValue, dtk);


    /// <summary>
    /// Nexts the object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="r">The r.</param>
    /// <param name="lValues">The l values.</param>
    /// <returns></returns>
    public static T NextObject<T>( this Random r, IList<T> lValues ) => lValues [r.Next(lValues.Count)];


    /// <summary>
    /// Nexts the object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="r">The r.</param>
    /// <param name="cValues">The c values.</param>
    /// <returns></returns>
    public static T NextObject<T>( this Random r, ICollection<T> cValues )
    {
        int iSelectedValue = r.Next(cValues.Count);
        int iCounter = 0;

        IEnumerator<T> e = cValues.GetEnumerator();

        while( e.MoveNext() )
        {
            if( iCounter++ == iSelectedValue )
            {
                return e.Current;
            }
        }

        return default;
    }


    /// <summary>
    /// Nexts the german license plate.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <returns></returns>
    public static string NextGermanLicensePlate( this Random r )
    {
        string strPart1 = r.NextString(2, 2);
        string strPart2 = r.NextString(2, 2);
        int iPart3 = r.Next(100, 9999);

        return $"{strPart1}-{strPart2} {iPart3}";
    }
}
