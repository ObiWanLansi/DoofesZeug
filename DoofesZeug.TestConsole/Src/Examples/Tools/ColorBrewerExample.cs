using System;

using DoofesZeug.Extensions;
using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Examples.Tools
{
    public static class ColorBrewerExample
    {
        public static void LoadColorBrewerAndDumpAll()
        {
            ColorBrewerCatalog cbc = ColorBrewerCatalog.Instance;

            cbc.ForEach(( colorscheme, colorbrewer ) =>
            {
                Console.Out.WriteLineAsync($"Color scheme: {colorscheme}");
                foreach( string strColor in colorbrewer.The8 )
                {
                    Console.Out.WriteLineAsync($"    {strColor.ToColor()}");
                }
            });
        }


        public static void LoadColorBrowerAndGetOnePaleteWith5Colors()
        {
            ColorBrewerCatalog cbc = ColorBrewerCatalog.Instance;
            ColorBrewer cb = cbc [ColorBrewerScheme.Blues];

            foreach( string strColor in cb.The5 )
            {
                Console.Out.WriteLineAsync($"{strColor.ToColor().ToHtml()}");
            }
        }
    }
}
