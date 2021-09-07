using System.Drawing;



namespace DoofesZeug.Extensions
{
    public static class ColorExtension
    {
        /// <summary>
        /// Color to HTML.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static string ToHtml( this Color color ) => $"#{color.R:X2}{color.G:X2}{color.B:X2}";


        /// <summary>
        /// Color to hexadecimal.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        public static string ToHex( this Color color ) => $"0x{color.R:X2}{color.G:X2}{color.B:X2}";
    }
}
