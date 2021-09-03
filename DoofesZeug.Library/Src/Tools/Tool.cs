using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using DoofesZeug.Container;

using Newtonsoft.Json;

namespace DoofesZeug.Tools
{
    public static class Tool
    {
        /// <summary>
        /// Franz jagt im komplett verwahrlosten Taxi quer durch Bayern.
        /// </summary>
        public static readonly string FRANZ = "Franz jagt im komplett verwahrlosten Taxi quer durch Bayern.";

        /// <summary>
        /// The quick brown fox jumps over a lazy dog.
        /// </summary>
        public static readonly string FOX = "The quick brown fox jumps over a lazy dog.";

        /// <summary>
        /// Vom Ödipuskomplex maßlos gequält, übt Wilfried zyklisches Jodeln.
        /// </summary>
        public static readonly string WILFRIED = "Vom Ödipuskomplex maßlos gequält, übt Wilfried zyklisches Jodeln.";

        /// <summary>
        /// Falsches Üben von Xylophonmusik quält jeden größeren Zwerg.
        /// </summary>
        public static readonly string XYLOPHONMUSIK = "Falsches Üben von Xylophonmusik quält jeden größeren Zwerg.";

        /// <summary>
        /// The allchars
        /// </summary>
        public static readonly string ALLCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZÖÄÜabcdefghijklmnopqrstuvwxyzöäü0123456789/*-+!\"§$%&()=?,.;:@€µ#'´`<>|^°\\";

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the size of the human readable.
        /// </summary>
        /// <param name="lSize">Size of the l.</param>
        /// <returns></returns>
        public static string GetHumanReadableSize( long lSize )
        {
            if( lSize >= 1099511627776 )
            {
                return $"{(float) lSize / 1099511627776:F} Tb";
            }

            if( lSize >= 1073741824 )
            {
                return $"{(float) lSize / 1073741824:F} Gb";
            }

            if( lSize >= 1048576 )
            {
                return $"{(float) lSize / 1048576:F} Mb";
            }

            if( lSize >= 1024 )
            {
                return $"{(float) lSize / 1024:F} Kb";
            }

            return lSize + " Bytes";
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// The datetimeformats
        /// </summary>
        public static readonly string [] DATETIMEFORMATS =
        {
            "dd.MM.yyyy, HH:mm:ss" ,
            "dd.MM.yyyy HH:mm:ss" ,
            "dd.MM.yyyy, HH:mm" ,
            "dd.MM.yyyy HH:mm" ,
            "dd.MM.yyyy" ,
            "ddMMyyyy_HHmmss" ,
            "yyyyMMdd_HHmmss" ,
            "yyyy-MM-dd" ,
            "dd-MM-yyyy"
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Enums to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">tEnum</exception>
        public static List<T> EnumToList<T>()
        {
            Type tEnum = typeof(T);

            return tEnum.IsEnum == false ? throw new ArgumentException(nameof(tEnum)) : Enum.GetValues(tEnum).Cast<T>().ToList();
        }

        /// <summary>
        /// Enums to string list.
        /// </summary>
        /// <param name="tEnum">The t enum.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">tEnum</exception>
        public static StringList EnumToStringList( Type tEnum )
        {
            return tEnum.IsEnum == false ? throw new ArgumentException($"The type '{tEnum.FullName}' is not an enumeration!", nameof(tEnum)) : new StringList(Enum.GetNames(tEnum));
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Numbers to roman.
        /// </summary>
        /// <param name="uValue">The u value.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Die Zahl ist zu groß um als römische Zahl darstellen zu können!</exception>
        /// <exception cref="ArgumentException">Die Zahl ist zu groß um als römische Zahl darstellen zu können!</exception>
        public static string NumberToRoman( ushort uValue )
        {
            if( uValue > 3999 )
            {
                throw new ArgumentException("Die Zahl ist zu groß um als römische Zahl darstellen zu können!");
            }

            if( uValue == 0 )
            {
                return string.Empty;
            }

            StringBuilder sb = new(8);

            SortedDictionary<ushort, string> mapping = new()
            {
                { 1, "I" },
                { 4, "IV" },
                { 5, "V" },
                { 9, "IX" },
                { 10, "X" },
                { 40, "XL" },
                { 50, "L" },
                { 90, "XC" },
                { 100, "C" },
                { 400, "CD" },
                { 500, "D" },
                { 900, "CM" },
                { 1000, "M" },
            };

            foreach( KeyValuePair<ushort, string> kvp in mapping.Reverse() )
            {
                while( uValue >= kvp.Key )
                {
                    uValue -= kvp.Key;
                    sb.Append(kvp.Value);
                }
            }

            return sb.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <param name="strSize">Size of the STR.</param>
        /// <param name="lDefault">The l default.</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">Die Einheit Tb wird nicht unterstützt!</exception>
        public static long GetSize( string strSize, long lDefault )
        {
            if( string.IsNullOrEmpty(strSize) )
            {
                return lDefault;
            }

            StringBuilder sbDigits = new(3);
            StringBuilder sbFactor = new(2);

            foreach( char c in strSize.Trim().ToLower() )
            {
                if( char.IsDigit(c) )
                {
                    sbDigits.Append(c);
                }
                else
                {
                    if( char.IsLetter(c) )
                    {
                        sbFactor.Append(c);
                    }
                }
            }

            // Wenn eine Exception auftritt, geben wir diese ersteinmal weiter ...
            long lValue = long.Parse(sbDigits.ToString());

            switch( sbFactor.ToString() )
            {
                case "tb":
                    throw new NotSupportedException("Die Einheit Tb wird nicht unterstützt!");

                case "gb":
                    return lValue * 1024 * 1024 * 1024;

                case "mb":
                    return lValue * 1024 * 1024;

                case "kb":
                    return lValue * 1024;

                case "b":
                    return lValue;
            }

            return lDefault;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the uptime.
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetUptime() => TimeSpan.FromMilliseconds(Environment.TickCount);


        /// <summary>
        /// Liefert einen eindeutige GUID.
        /// </summary>
        /// <returns></returns>
        public static string GUID() => Guid.NewGuid().ToString();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Überprüft ob ein Bit in einem Wert gesetzt ist.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <param name="iBit">The i bit.</param>
        /// <returns>
        ///   <c>true</c> if [is bit set] [the specified i value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsBitSet( int iValue, int iBit ) => ( iValue & 1 << iBit ) == 1 << iBit;


        /// <summary>
        /// Gets the bit value.
        /// </summary>
        /// <param name="iStatusWert">The i status wert.</param>
        /// <param name="iStartBit">The i start bit.</param>
        /// <param name="iStopBit">The i stop bit.</param>
        /// <returns></returns>
        public static int GetBitValue( int iStatusWert, int iStartBit, int iStopBit ) => iStopBit < iStartBit ? -1 : ( iStatusWert & ( 1 << iStopBit + 1 ) - 1 ) >> iStartBit;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        ///// <summary>
        ///// Froms the json.
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="strJson">The string json.</param>
        ///// <returns></returns>
        //public static T FromJson<T>(string strJson) => (T) JsonConvert.DeserializeObject(strJson);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Combines the specified lists.
        /// </summary>
        /// <param name="lists">The lists.</param>
        /// <returns></returns>
        public static IEnumerable<object []> Combine( params IList [] lists )
        {
            int iTotalCount = 1;
            int [] iColumnLength = new int [lists.Length];
            int [] iColumnChanges = new int [lists.Length];

            {
                int iColumn = 0;
                int iPreChange = 1;

                foreach( IList list in lists )
                {
                    iPreChange *= list.Count;

                    iColumnChanges [iColumn] = iPreChange;
                    iColumnLength [iColumn] = list.Count;

                    iTotalCount *= list.Count;

                    iColumn++;
                }
            }

            for( int iColumn = 0 ; iColumn < lists.Length ; iColumn++ )
            {
                iColumnChanges [iColumn] = iTotalCount / iColumnChanges [iColumn];
            }

            for( int iRow = 0 ; iRow < iTotalCount ; iRow++ )
            {
                object [] row = new object [lists.Length];

                int iColumn = 0;

                foreach( IList list in lists )
                {
                    row [iColumn] = list [iRow / iColumnChanges [iColumn] % iColumnLength [iColumn]];
                    iColumn++;
                }

                yield return row;
            }
        }
    }
}
