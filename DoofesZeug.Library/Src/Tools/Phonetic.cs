using System;
using System.Text;



namespace DoofesZeug.Tools
{
    public static class Phonetic
    {
        /// <summary>
        /// Classic soundex algorithm.
        /// </summary>
        public static class Soundex
        {
            //  ABCDEFGHIJKLMNOPQRSTUVWXYZ
            /// <summary>
            /// The values
            /// </summary>
            private const string _values = "01230120022455012623010202";

            /// <summary>
            /// The encoding length
            /// </summary>
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



        /// <summary>
        /// Implements the Metaphone algorithm.
        /// </summary>
        public static class Metaphone
        {
            // Constants
            private const int MAXENCODEDLENGTH = 6;
            private const char NULLCHAR = (char) 0;
            private const string VOWELS = "AEIOU";

            // For tracking position within current string
            private static string _text = null;
            private static int _pos = 0;

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            /// <summary>
            /// Encodes the given text using the Metaphone algorithm.
            /// </summary>
            /// <param name="strText">Text to encode</param>
            /// <returns></returns>
            public static string Encode( string strText )
            {
                // Process normalized text
                InitializeText(Normalize(strText));

                // Write encoded string to StringBuilder
                StringBuilder builder = new(8);

                // Special handling of some string prefixes:
                //     PN, KN, GN, AE, WR, WH and X
                switch( Peek() )
                {
                    case 'P':
                    case 'K':
                    case 'G':
                        if( Peek(1) == 'N' )
                        {
                            MoveAhead();
                        }

                        break;

                    case 'A':
                        if( Peek(1) == 'E' )
                        {
                            MoveAhead();
                        }

                        break;

                    case 'W':
                        if( Peek(1) == 'R' )
                        {
                            MoveAhead();
                        }
                        else if( Peek(1) == 'H' )
                        {
                            builder.Append('W');
                            MoveAhead(2);
                        }
                        break;

                    case 'X':
                        builder.Append('S');
                        MoveAhead();
                        break;
                }

                //
                while( !EndOfText() && builder.Length < MAXENCODEDLENGTH )
                {
                    // Cache this character
                    char c = Peek();

                    // Ignore duplicates except CC
                    if( c == Peek(-1) && c != 'C' )
                    {
                        MoveAhead();
                        continue;
                    }

                    // Don't change F, J, L, M, N, R or first-letter vowel
                    if( IsOneOf(c, "FJLMNR") ||
                         builder.Length == 0 && IsOneOf(c, VOWELS) )
                    {
                        builder.Append(c);
                        MoveAhead();
                    }
                    else
                    {
                        int charsConsumed = 1;

                        switch( c )
                        {
                            case 'B':
                                // B = 'B' if not -MB
                                if( Peek(-1) != 'M' || Peek(1) != NULLCHAR )
                                {
                                    builder.Append('B');
                                }

                                break;

                            case 'C':
                                // C = 'X' if -CIA- or -CH-
                                // Else 'S' if -CE-, -CI- or -CY-
                                // Else 'K' if not -SCE-, -SCI- or -SCY-
                                if( Peek(-1) != 'S' || !IsOneOf(Peek(1), "EIY") )
                                {
                                    if( Peek(1) == 'I' && Peek(2) == 'A' )
                                    {
                                        builder.Append('X');
                                    }
                                    else if( IsOneOf(Peek(1), "EIY") )
                                    {
                                        builder.Append('S');
                                    }
                                    else if( Peek(1) == 'H' )
                                    {
                                        if( _pos == 0 && !IsOneOf(Peek(2), VOWELS) ||
                                            Peek(-1) == 'S' )
                                        {
                                            builder.Append('K');
                                        }
                                        else
                                        {
                                            builder.Append('X');
                                        }

                                        charsConsumed++;    // Eat 'CH'
                                    }
                                    else
                                    {
                                        builder.Append('K');
                                    }
                                }
                                break;

                            case 'D':
                                // D = 'J' if DGE, DGI or DGY
                                // Else 'T'
                                if( Peek(1) == 'G' && IsOneOf(Peek(2), "EIY") )
                                {
                                    builder.Append('J');
                                }
                                else
                                {
                                    builder.Append('T');
                                }

                                break;

                            case 'G':
                                // G = 'F' if -GH and not B--GH, D--GH, -H--GH, -H---GH
                                // Else dropped if -GNED, -GN, -DGE-, -DGI-, -DGY-
                                // Else 'J' if -GE-, -GI-, -GY- and not GG
                                // Else K
                                if( ( Peek(1) != 'H' || IsOneOf(Peek(2), VOWELS) ) &&
                                    ( Peek(1) != 'N' || Peek(1) != NULLCHAR &&
                                    ( Peek(2) != 'E' || Peek(3) != 'D' ) ) &&
                                    ( Peek(-1) != 'D' || !IsOneOf(Peek(1), "EIY") ) )
                                {
                                    if( IsOneOf(Peek(1), "EIY") && Peek(2) != 'G' )
                                    {
                                        builder.Append('J');
                                    }
                                    else
                                    {
                                        builder.Append('K');
                                    }
                                }
                                // Eat GH
                                if( Peek(1) == 'H' )
                                {
                                    charsConsumed++;
                                }

                                break;

                            case 'H':
                                // H = 'H' if before or not after vowel
                                if( !IsOneOf(Peek(-1), VOWELS) || IsOneOf(Peek(1), VOWELS) )
                                {
                                    builder.Append('H');
                                }

                                break;

                            case 'K':
                                // K = 'C' if not CK
                                if( Peek(-1) != 'C' )
                                {
                                    builder.Append('K');
                                }

                                break;

                            case 'P':
                                // P = 'F' if PH
                                // Else 'P'
                                if( Peek(1) == 'H' )
                                {
                                    builder.Append('F');
                                    charsConsumed++;    // Eat 'PH'
                                }
                                else
                                {
                                    builder.Append('P');
                                }

                                break;

                            case 'Q':
                                // Q = 'K'
                                builder.Append('K');
                                break;

                            case 'S':
                                // S = 'X' if SH, SIO or SIA
                                // Else 'S'
                                if( Peek(1) == 'H' )
                                {
                                    builder.Append('X');
                                    charsConsumed++;    // Eat 'SH'
                                }
                                else if( Peek(1) == 'I' && IsOneOf(Peek(2), "AO") )
                                {
                                    builder.Append('X');
                                }
                                else
                                {
                                    builder.Append('S');
                                }

                                break;

                            case 'T':
                                // T = 'X' if TIO or TIA
                                // Else '0' if TH
                                // Else 'T' if not TCH
                                if( Peek(1) == 'I' && IsOneOf(Peek(2), "AO") )
                                {
                                    builder.Append('X');
                                }
                                else if( Peek(1) == 'H' )
                                {
                                    builder.Append('0');
                                    charsConsumed++;    // Eat 'TH'
                                }
                                else if( Peek(1) != 'C' || Peek(2) != 'H' )
                                {
                                    builder.Append('T');
                                }

                                break;

                            case 'V':
                                // V = 'F'
                                builder.Append('F');
                                break;

                            case 'W':
                            case 'Y':
                                // W,Y = Keep if not followed by vowel
                                if( IsOneOf(Peek(1), VOWELS) )
                                {
                                    builder.Append(c);
                                }

                                break;

                            case 'X':
                                // X = 'S' if first character (already done)
                                // Else 'KS'
                                builder.Append("KS");
                                break;

                            case 'Z':
                                // Z = 'S'
                                builder.Append('S');
                                break;
                        }
                        // Advance over consumed characters
                        MoveAhead(charsConsumed);
                    }
                }
                // Return result
                return builder.ToString();
            }

            //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


            private static void InitializeText( string text )
            {
                _text = text;
                _pos = 0;
            }


            private static bool EndOfText() => _pos >= _text.Length;


            private static void MoveAhead() => MoveAhead(1);


            private static void MoveAhead( int count ) => _pos = Math.Min(_pos + count, _text.Length);


            private static char Peek() => Peek(0);


            private static char Peek( int ahead )
            {
                int pos = _pos + ahead;

                return pos < 0 || pos >= _text.Length ? NULLCHAR : _text [pos];
            }


            private static bool IsOneOf( char c, string chars ) => chars.IndexOf(c) != -1;


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

        } // end static public class Metaphone

    }
}