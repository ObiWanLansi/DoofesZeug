using System;
using System.Text;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Extensions;



namespace DoofesZeug.Tools.Misc
{
    [Description("An small class to generate a lorem ipsum text.")]
    [Example("O:\\DoofesZeug\\DoofesZeug.TestConsole\\Src\\Examples\\Tools\\LoremIpsumExample.cs")]
    public static class LoremIpsum
    {
        private static readonly string LI_START = "Lorem ipsum dolor sit amet,";

        private static readonly Random rand = new();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        #region LoremIpsumWords
        /// <summary>
        /// The lorem ipsum words
        /// </summary>
        private static readonly string [] LOREM_IPSUM_WORDS = {
            "lorem","ipsum","dolor","sit","amet",
            "consectetuer","adipiscing","elit","donec","id",
            "eros","quisque","nisl","lacinia","cursus",
            "tincidunt","porttitor","non","leo","nunc",
            "metus","nibh","semper","ac","interdum",
            "nec","fringilla","ut","felis","tempor",
            "ligula","suspendisse","quis","est","commodo",
            "dignissim","mauris","neque","convallis","urna",
            "sed","orci","turpis","pretium","consequat",
            "venenatis","et","risus","cras","facilisis",
            "augue","in","praesent","pellentesque","diam",
            "vestibulum","justo","curabitur","dui","vivamus",
            "vitae","at","enim","laoreet","phasellus",
            "eget","ornare","pulvinar","a","aenean",
            "condimentum","nullam","ante","fermentum","scelerisque",
            "velit","morbi","nam","rhoncus","dapibus",
            "libero","suscipit","hendrerit","tortor","integer",
            "congue","sem","eu","mi","tellus",
            "nonummy","lacus","duis","wisi","aliquam",
            "nulla","cum","sociis","natoque","penatibus",
            "magnis","dis","parturient","montes","nascetur",
            "ridiculus","mus","sodales","proin","odio",
            "auctor","sollicitudin","maecenas","magna","tristique",
            "malesuada","euismod","vel","porta","sapien",
            "tempus","mattis","massa","purus","arcu",
            "eleifend","mollis","aliquet","pharetra","habitant",
            "senectus","netus","fames","egestas","sagittis",
            "gravida","molestie","facilisi","volutpat","feugiat",
            "accumsan","pede","dictum","lobortis","hac",
            "habitasse","platea","dictumst","rutrum","iaculis",
            "faucibus","fusce","ultrices","ullamcorper","quam",
            "lansi","analus","corinnus","felix","nussi",
            "willus","gabrielus","ancus","nasus","wingtsun",
            "i","e","sinus","illuminati","sanktus","spiritus",
            "lancer","nitus","sammy","shari"
        };
        #endregion

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the lorem ipsum.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="wordsperline">The wordsperline.</param>
        /// <param name="lineending">The lineending.</param>
        /// <returns></returns>
        public static string GetLoremIpsum( uint lines = 20, uint wordsperline = 20, string lineending = null )
        {
            if( wordsperline < 10 )
            {
                wordsperline = 10;
            }

            if( lines == 0 )
            {
                lines = 5;
            }

            if( lineending.IsEmpty() == true )
            {
                lineending = "\r\n";
            }

            //-------------------------------------------------------------------------------------

            int length = LOREM_IPSUM_WORDS.Length;
            int iPointRand = rand.Next(10) + 3;
            bool bNewLine = false;
            uint iLineCounter = 0;
            uint iLineWordCounter = 5;
            uint iSentenceWordCounter = 0;
            bool bSentenceStart = false;

            StringBuilder sb = new(512);

            sb.Append(LI_START);

            while( iLineCounter++ < lines )
            {
                while( iLineWordCounter++ < wordsperline )
                {
                    string strWord = LOREM_IPSUM_WORDS [rand.Next(length)];

                    if( bSentenceStart == true )
                    {
                        strWord = strWord.CapitalizeOnlyFirstLetter();
                        bSentenceStart = false;
                    }

                    if( bNewLine == true )
                    {
                        sb.Append(strWord);
                        bNewLine = false;
                    }
                    else
                    {
                        sb.Append(' ');
                        sb.Append(strWord);
                    }

                    iSentenceWordCounter++;

                    if( iSentenceWordCounter > iPointRand )
                    {
                        sb.Append('.');

                        // Es sollten schon midenstens drei Wörter pro Satz sein, maximal also 12
                        iPointRand = rand.Next(10) + 3;

                        iSentenceWordCounter = 0;
                        bSentenceStart = true;
                    }
                }

                iLineWordCounter = 0;

                if( iLineCounter < lines )
                {
                    sb.Append(lineending);
                    bNewLine = true;
                }
                else
                {
                    sb.Append('.');
                }
            }

            //-------------------------------------------------------------------------------------

            return sb.ToString();
        }
    }
}
