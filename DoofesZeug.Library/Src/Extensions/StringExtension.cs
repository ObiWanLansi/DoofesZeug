using System;
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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


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
        /// Removes the extension.
        /// </summary>
        /// <param name="strFilename">The string filename.</param>
        /// <returns></returns>
        public static string RemoveExtension( this string strFilename )
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
    }
}
