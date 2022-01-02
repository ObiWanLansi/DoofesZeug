using System;
using System.Text;
using System.Threading;

using DoofesZeug.Extensions;



namespace DoofesZeug.Tools.Misc
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// The default foreground color
        /// </summary>
        public static readonly ConsoleColor DefaultForegroundColor = Console.ForegroundColor;

        /// <summary>
        /// The default background color
        /// </summary>
        public static readonly ConsoleColor DefaultBackgroundColor = Console.BackgroundColor;




        /// <summary>
        /// Just wait for a key.
        /// </summary>
        public static void Getch() => Console.ReadKey(true);


        /// <summary>
        /// Just wait for a specified key.
        /// </summary>
        /// <param name="ck">The ck.</param>
        public static void Getch( ConsoleKey ck )
        {
            do
            {
                while( Console.KeyAvailable == false )
                {
                    Thread.Sleep(50);
                }
            }
            while( Console.ReadKey(true).Key != ck );
        }


        /// <summary>
        /// Display an optional text and wait for any key.
        /// </summary>
        /// <param name="strMessage">The Message to display, can be null.</param>
        public static void Getch( string strMessage )
        {
            if( strMessage.IsNotEmpty() )
            {
                Output(strMessage);
            }

            Console.ReadKey(true);
        }


        /// <summary>
        /// Getches the specified ck.
        /// </summary>
        /// <param name="ck">The ck.</param>
        /// <param name="strMessage">The string message.</param>
        public static void Getch( ConsoleKey ck, string strMessage )
        {
            if( strMessage.IsNotEmpty() )
            {
                Output(strMessage);
            }

            Getch(ck);
        }


        /// <summary>
        /// Waits for escape.
        /// </summary>
        public static void WaitForEscape() => Getch(ConsoleKey.Escape, "\nPress The Escape Key To Continue ...");

        //-------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gibt eine Fehlermeldung auf der Konsole aus.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        public static void OutputError( string strMessage )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(strMessage);
            Console.ForegroundColor = DefaultForegroundColor;
        }


        /// <summary>
        /// Outputs the error.
        /// </summary>
        /// <param name="strFormat">The STR format.</param>
        /// <param name="param">The param.</param>
        public static void OutputError( string strFormat, params object [] param )
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Error.WriteLine(strFormat, param);
            Console.ForegroundColor = DefaultForegroundColor;
        }


        /// <summary>
        /// Outputs the specified STR format.
        /// </summary>
        /// <param name="strFormat">The STR format.</param>
        /// <param name="param">The param.</param>
        public static void Output( string strFormat, params object [] param )
        {
            Console.ForegroundColor = DefaultForegroundColor;

            Console.Out.WriteLine(strFormat, param);
        }


        /// <summary>
        /// Gibt eine Meldung auf der Konsole aus.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        /// <param name="ccForegroundColor">Color of the cc foreground.</param>
        /// <param name="iIndent">The i indent.</param>
        public static void Output( string strMessage, ConsoleColor ccForegroundColor, int iIndent )
        {
            Console.ForegroundColor = ccForegroundColor;

            if( iIndent > 0 )
            {
                StringBuilder sb = new StringBuilder();

                for( int iCounter = 0 ; iCounter < iIndent ; iCounter++ )
                {
                    sb.Append("    ");
                }

                Console.Out.Write(sb);
            }

            Console.Out.WriteLine(strMessage);
            Console.ForegroundColor = DefaultForegroundColor;
        }


        /// <summary>
        /// Gibt eine Meldung auf der Konsole aus.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        /// <param name="ccForegroundColor">Color of the cc foreground.</param>
        public static void Output( string strMessage, ConsoleColor ccForegroundColor ) => Output(strMessage, ccForegroundColor, 0);


        /// <summary>
        /// Gibt eine Meldung auf der Konsole aus.
        /// </summary>
        /// <param name="strMessage">The string message.</param>
        public static void Output( string strMessage )
        {
            Console.ForegroundColor = DefaultForegroundColor;

            Console.Out.WriteLine(strMessage);
        }

    } // end static public class ConsoleHelper
}
