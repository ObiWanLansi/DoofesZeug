using System.Collections.Generic;
using System.Text;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Misc;

[Description("An simple class to convert text to morse signs.")]
public static class Morse
{
    /// <summary>
    /// The morse
    /// </summary>
    public static readonly SortedDictionary<char, string> MORSE = new()
    {
        { 'a', ".-" },
        { 'b', "-..." },
        { 'c', "-.-." },
        { 'd', "-.." },
        { 'e', "." },
        { 'f', "..-." },
        { 'g', "--." },
        { 'h', "...." },
        { 'i', ".." },
        { 'j', ".---" },
        { 'k', "-.-" },
        { 'l', ".-.." },
        { 'm', "--" },
        { 'n', "-." },
        { 'o', "---" },
        { 'p', ".--." },
        { 'q', "--.-" },
        { 'r', ".-." },
        { 's', "..." },
        { 't', "-" },
        { 'u', "..-" },
        { 'v', "...-" },
        { 'w', ".--" },
        { 'x', "-..-" },
        { 'y', "-.--" },
        { 'z', "--.." },

        { '0', "-----" },
        { '1', ".----" },
        { '2', "..---" },
        { '3', "...--" },
        { '4', "....-" },
        { '5', "....." },
        { '6', "-...." },
        { '7', "--..." },
        { '8', "---.." },
        { '9', "----." },

        { ' ', " " }
    };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the morse.
    /// </summary>
    /// <param name="strContent">Content of the string.</param>
    /// <param name="cLetterSplitter">The c letter splitter.</param>
    /// <returns></returns>
    public static string GetMorse(string strContent, char cLetterSplitter = ' ')
    {
        StringBuilder sb = new(8192);

        strContent = strContent.ToLower();

        foreach (char c in strContent)
        {
            string strSpell = MORSE.ContainsKey(c) == true
                ? MORSE[c]
                : c switch
                {
                    'ä' => MORSE['a'] + " " + MORSE['e'],
                    'ö' => MORSE['o'] + " " + MORSE['e'],
                    'ü' => MORSE['u'] + " " + MORSE['e'],
                    _ => $">{c}<",
                };
            sb.Append($"{strSpell}{cLetterSplitter}");
        }


        return sb.ToString();
    }


    /// <summary>
    /// Enumerates the morse.
    /// </summary>
    /// <param name="strContent">Content of the string.</param>
    /// <returns></returns>
    public static IEnumerable<string> EnumerateMorse(string strContent)
    {
        strContent = strContent.ToLower();

        foreach (char c in strContent)
        {
            if (MORSE.ContainsKey(c) == true)
            {
                yield return MORSE[c];
            }
            else
            {
                switch (c)
                {
                    case 'ä':
                        yield return MORSE['a'];
                        yield return MORSE['e'];
                        break;

                    case 'ö':
                        yield return MORSE['o'];
                        yield return MORSE['e'];
                        break;

                    case 'ü':
                        yield return MORSE['u'];
                        yield return MORSE['e'];
                        break;

                    default:
                        yield return $"UNKNOWN CHAR: {c}";
                        break;
                }
            }
        }
    }
}
