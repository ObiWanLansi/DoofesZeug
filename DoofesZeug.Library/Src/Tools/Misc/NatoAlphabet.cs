using System.Collections.Generic;
using System.Text;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Misc
{
    [Description("An static class to spell an word with the NATO alphabet.")]
    public static class NatoAlphabet
    {
        /// <summary>
        /// ICAO - Alphabet
        /// </summary>
        public static readonly SortedDictionary<char, string> NATO_ALPHABET = new()
        {
            { 'a', "Alpha" },
            { 'b', "Bravo" },
            { 'c', "Charlie" },
            { 'd', "Delta" },
            { 'e', "Echo" },
            { 'f', "Foxtrot" },
            { 'g', "Golf" },
            { 'h', "Hotel" },
            { 'i', "India" },
            { 'j', "Juliet" },
            { 'k', "Kilo" },
            { 'l', "Lima" },
            { 'm', "Mike" },
            { 'n', "November" },
            { 'o', "Oskar" },
            { 'p', "Papa" },
            { 'q', "Quebec" },
            { 'r', "Romeo" },
            { 's', "Sierra" },
            { 't', "Tango" },
            { 'u', "Uniform" },
            { 'v', "Victor" },
            { 'w', "Whisky" },
            { 'x', "Xray" },
            { 'y', "Yankee" },
            { 'z', "Zulu" },
            { ' ', " " },
            { '0', "Zero" },
            { '1', "One" },
            { '2', "Two" },
            { '3', "Three" },
            { '4', "Four" },
            { '5', "Five" },
            { '6', "Six" },
            { '7', "Seven" },
            { '8', "Eight" },
            { '9', "Nine" }
        };

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the spelling.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static string GetSpelling( string strContent )
        {
            StringBuilder sb = new(8192);

            strContent = strContent.ToLower();

            foreach( char c in strContent )
            {
                string strSpell = NATO_ALPHABET.ContainsKey(c) == true
                    ? NATO_ALPHABET [c]
                    : c switch
                    {
                        'ä' => NATO_ALPHABET ['a'] + " " + NATO_ALPHABET ['e'],
                        'ö' => NATO_ALPHABET ['o'] + " " + NATO_ALPHABET ['e'],
                        'ü' => NATO_ALPHABET ['u'] + " " + NATO_ALPHABET ['e'],
                        _ => $">{c}<",
                    };
                sb.Append($"{strSpell} ");
            }

            return sb.ToString();
        }


        /// <summary>
        /// Enumerates the spelling.
        /// </summary>
        /// <param name="strContent">Content of the string.</param>
        /// <returns></returns>
        public static IEnumerable<string> EnumerateSpelling( string strContent )
        {
            strContent = strContent.ToLower();

            foreach( char c in strContent )
            {
                if( NATO_ALPHABET.ContainsKey(c) == true )
                {
                    yield return NATO_ALPHABET [c];
                }
                else
                {
                    switch( c )
                    {
                        case 'ä':
                            yield return NATO_ALPHABET ['a'];
                            yield return NATO_ALPHABET ['e'];
                            break;

                        case 'ö':
                            yield return NATO_ALPHABET ['o'];
                            yield return NATO_ALPHABET ['e'];
                            break;

                        case 'ü':
                            yield return NATO_ALPHABET ['u'];
                            yield return NATO_ALPHABET ['e'];
                            break;

                        default:
                            yield return $"UNKNOWN CHAR: {c}";
                            break;
                    }
                }
            }
        }
    }
}
