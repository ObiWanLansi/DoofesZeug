using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Web;



namespace DoofesZeug.Extensions
{
    /// <summary>
    /// Eine Erweiterungsklasse für unseren lieblichen String.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Removes the quotation.
        /// </summary>
        /// <param name="strContent">Content of the STR.</param>
        /// <returns></returns>
        public static string RemoveQuotation( this string strContent )
        {
            string strTemp = strContent.Trim();

            return strTemp.StartsWith("\"") && strTemp.EndsWith("\"") ? strTemp.Substring(1, strContent.Length - 2) : strContent;
        }


        /// <summary>
        /// Shortens the specified i maximum length.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="iMaxLength">Maximum length of the i.</param>
        /// <returns></returns>
        public static string Shorten( this string strContent, int iMaxLength ) => strContent.Length > iMaxLength ? $"{strContent.Substring(0, iMaxLength - 4)} ..." : strContent;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Liefert zurück ob ein String null oder dessen Länge 0 ist.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns>
        ///   <c>true</c> if the specified string content is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty( this string strContent ) => string.IsNullOrEmpty(strContent);


        /// <summary>
        /// Liefert zurück ob ein String nicht null oder dessen Länge &gt; 0 ist.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns>
        ///   <c>true</c> if [is not empty] [the specified string content]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty( this string strContent ) => !string.IsNullOrEmpty(strContent);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Reverses the specified STR content.
        /// </summary>
        /// <param name="strContent">Content of the STR.</param>
        /// <returns></returns>
        public static string Reverse( this string strContent )
        {
            char [] cOld = strContent.ToCharArray();
            char [] cNew = new char [cOld.Length];

            for( int iCounter = 0 ; iCounter < cOld.Length ; iCounter++ )
            {
                cNew [cOld.Length - iCounter - 1] = cOld [iCounter];
            }

            return new string(cNew);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Uppercase
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Upper( this string strContent ) => strContent.ToUpper();


        /// <summary>
        /// Lowercase
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Lower( this string strContent ) => strContent.ToLower();


        /// <summary>
        /// Capitalizes the only first letter.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string CapitalizeOnlyFirstLetter( this string strContent )
        {
            char [] aData = strContent.ToLower().ToCharArray();

            if( char.IsLower(aData [0]) )
            {
                aData [0] -= (char) 0x20;
            }

            return new string(aData);
        }


        /// <summary>
        /// Capitalizes the specified string content.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string Capitalize( this string strContent )
        {
            char [] aData = strContent.ToLower().ToCharArray();

            for( int iCounter = 0 ; iCounter < aData.Length ; iCounter++ )
            {
                if( iCounter == 0 )
                {
                    if( char.IsLetter(aData [iCounter]) )
                    {
                        aData [iCounter] -= (char) 0x20;
                    }
                }
                else
                {
                    if( char.IsLetter(aData [iCounter - 1]) == false && aData [iCounter - 1] != '\'' && char.IsLetter(aData [iCounter]) )
                    {
                        aData [iCounter] -= (char) 0x20;
                    }
                }
            }

            return new string(aData);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Equalses the ignore case.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="strOtherString">The string other string.</param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase( this string strContent, string strOtherString ) => strContent.Equals(strOtherString, StringComparison.CurrentCultureIgnoreCase);


        /// <summary>
        /// Because we have an LastIndexOf, we also need an FirstIndexOf.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int FirstIndexOf( this string strContent, char value ) => strContent.IndexOf(value);


        /// <summary>
        /// Because we have an LastIndexOf, we also need an FirstIndexOf.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int FirstIndexOf( this string strContent, string value ) => strContent.IndexOf(value);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Determines whether [contains non letter characters].
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns>
        ///   <c>true</c> if [contains non letter characters] [the specified string content]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsNonLetterCharacters( this string strContent )
        {
            foreach( char c in strContent )
            {
                if( char.IsLetter(c) == false )
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Determines whether [contains control characters].
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns>
        ///   <c>true</c> if [contains control characters] [the specified string content]; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsControlCharacters( this string strContent )
        {
            foreach( char c in strContent )
            {
                if( char.IsControl(c) == true )
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Expands the string array.
        /// </summary>
        /// <param name="strArray">The string array.</param>
        /// <returns></returns>
        public static string ExpandStringArray( this string [] strArray )
        {
            StringBuilder sb = new();

            for( int iCounter = 0 ; iCounter < strArray.Length ; iCounter++ )
            {
                sb.Append(strArray [iCounter]);

                if( iCounter < strArray.Length - 1 )
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Repeats the specified i count.
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <param name="iCount">The i count.</param>
        /// <returns></returns>
        public static string Repeat( this string strValue, int iCount )
        {
            StringBuilder sb = new();

            for( int iCounter = 0 ; iCounter < iCount ; iCounter++ )
            {
                sb.Append(strValue);
            }

            return sb.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Removes the file extension from an filename.
        /// </summary>
        /// <param name="strFilename">The string filename.</param>
        /// <returns></returns>
        public static string RemoveFileExtension( this string strFilename )
        {
            int iIndex = strFilename.LastIndexOf('.');
            return iIndex > 0 ? strFilename.Substring(0, iIndex) : strFilename;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Replaces the HTML.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string ReplaceHtml( this string strContent ) => HttpUtility.HtmlEncode(strContent);


        private static readonly Dictionary<char, string> UMLAUTS = new()
        {
            { 'ä', "ae" },
            { 'ö', "oe" },
            { 'ü', "ue" },

            { 'Ä', "Ae" },
            { 'Ö', "Oe" },
            { 'Ü', "Ue" },

            { 'ß', "ss" }
        };


        /// <summary>
        /// Replaces the german umlauts.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string ReplaceGermanUmlauts( this string strContent )
        {
            StringBuilder sb = new(32);
            foreach( char c in strContent )
            {
                sb.Append(UMLAUTS.ContainsKey(c) ? UMLAUTS [c] : c);
            }
            return sb.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to flatstring.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="strDivider">The string divider.</param>
        /// <returns></returns>
        public static string ToFlatString( this string [] values, string strDivider = ", " )
        {
            StringBuilder sbFlatten = new(128);
            for( int iCounter = 0 ; iCounter < values.Length ; iCounter++ )
            {
                if( iCounter > 0 )
                {
                    sbFlatten.Append(strDivider);
                }
                sbFlatten.Append(values [iCounter]);
            }
            return sbFlatten.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Try to converts an string into a color.
        /// </summary>
        /// <param name="strColor">The color as string ( eg "0xFF00FF" or "#123456" or "Cyan").</param>
        /// <param name="cDefault">The c default.</param>
        /// <returns></returns>
        public static Color ToColor( this string strColor, Color? cDefault = null )
        {
            if( string.IsNullOrEmpty(strColor) )
            {
                return cDefault ?? Color.Transparent;
            }

            strColor = strColor.Trim().ToLower();

            // #123456
            if( strColor [0] == '#' )
            {
                string strHEXValue = "FF" + strColor.Substring(1);
                return Color.FromArgb(Convert.ToInt32(strHEXValue, 16));
            }

            // 0xFF00FF
            if( strColor.StartsWith("0x") )
            {
                string strHEXValue = "FF" + strColor.Substring(2);
                return Color.FromArgb(Convert.ToInt32(strHEXValue, 16));
            }

            // Color [Cyan]
            if( strColor.StartsWith("Color [") && strColor.EndsWith("]") )
            {
                strColor = strColor.Substring(7, strColor.Length - 8);
                return Color.FromName(strColor);
            }

            // rgb(252,141,89)
            if( strColor.StartsWith("rgb(") && strColor.EndsWith(")") )
            {
                strColor = strColor [4..];
                strColor = strColor [0..^1];

                string [] strArray = strColor.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if( strArray.Length == 3 )
                {
                    return Color.FromArgb(Convert.ToInt32(strArray [0]), Convert.ToInt32(strArray [1]), Convert.ToInt32(strArray [2]));
                }
            }

            // Cyan
            return Color.FromName(strColor);
        }
    }
}
