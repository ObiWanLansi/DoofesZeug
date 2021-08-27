using System.Text;



namespace DoofesZeug.Tools.Phonetic
{
    /// <summary>
    /// Classic soundex algorithm.
    /// </summary>
    public static class Soundex
    {
        private const string _values = "01230120022455012623010202";

        private const int EncodingLength = 4;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Soundex-encodes the given text
        /// </summary>
        /// <param name="strText">Text to be encoded</param>
        /// <returns></returns>
        public static string Encode( string strText )
        {
            char prevChar = ' ';

            // Normalize input
            strText = Normalize(strText);

            if( strText.Length == 0 )
            {
                return strText;
            }

            // Write result to StringBuilder
            StringBuilder builder = new(8);

            builder.Append(strText [0]);

            for( int i = 1 ; i < strText.Length && builder.Length < EncodingLength ; i++ )
            {
                // Get digit for this letter
                char c = _values [strText [i] - 'A'];

                // Add if not zero or same as last character
                if( c != '0' && c != prevChar )
                {
                    builder.Append(c);
                    prevChar = c;
                }
            }

            // Pad with trailing zeros
            while( builder.Length < EncodingLength )
            {
                builder.Append('0');
            }

            // Return result
            return builder.ToString();
        }


        private static string Normalize( string text )
        {
            StringBuilder builder = new(32);
            foreach( char c in text )
            {
                if( char.IsLetter(c) )
                {
                    builder.Append(char.ToUpper(c));
                }
            }
            return builder.ToString();
        }

    } // end static public class Soundex
}