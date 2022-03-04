using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

using DoofesZeug.Extensions;
using DoofesZeug.Tools.Enums;



namespace DoofesZeug.Tools.Misc
{
    public static class ConsoleHelper
    {
        ///// <summary>
        ///// The default foreground color
        ///// </summary>
        //public static readonly ConsoleColor DefaultForegroundColor = Console.ForegroundColor;

        ///// <summary>
        ///// The default background color
        ///// </summary>
        //public static readonly ConsoleColor DefaultBackgroundColor = Console.BackgroundColor;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



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
                Console.Out.WriteLineAsync(strMessage);
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
                Console.Out.WriteLineAsync(strMessage);
            }

            Getch(ck);
        }


        /// <summary>
        /// Waits for escape.
        /// </summary>
        public static void WaitForEscape() => Getch(ConsoleKey.Escape, "\nPress The Escape Key To Continue ...");

        //-------------------------------------------------------------------------------------------------------------


        ///// <summary>
        ///// Gibt eine Fehlermeldung auf der Konsole aus.
        ///// </summary>
        ///// <param name="strMessage">The string message.</param>
        //public static void OutputError( string strMessage )
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.Error.WriteLine(strMessage);
        //    Console.ForegroundColor = DefaultForegroundColor;
        //}


        ///// <summary>
        ///// Outputs the error.
        ///// </summary>
        ///// <param name="strFormat">The STR format.</param>
        ///// <param name="param">The param.</param>
        //public static void OutputError( string strFormat, params object [] param )
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.Error.WriteLine(strFormat, param);
        //    Console.ForegroundColor = DefaultForegroundColor;
        //}


        ///// <summary>
        ///// Outputs the specified STR format.
        ///// </summary>
        ///// <param name="strFormat">The STR format.</param>
        ///// <param name="param">The param.</param>
        //public static void Output( string strFormat, params object [] param )
        //{
        //    Console.ForegroundColor = DefaultForegroundColor;

        //    Console.Out.WriteLine(strFormat, param);
        //}


        ///// <summary>
        ///// Gibt eine Meldung auf der Konsole aus.
        ///// </summary>
        ///// <param name="strMessage">The string message.</param>
        ///// <param name="ccForegroundColor">Color of the cc foreground.</param>
        ///// <param name="iIndent">The i indent.</param>
        //public static void Output( string strMessage, ConsoleColor ccForegroundColor, int iIndent )
        //{
        //    ConsoleColor dfc = Console.ForegroundColor;

        //    Console.ForegroundColor = ccForegroundColor;

        //    if( iIndent > 0 )
        //    {
        //        StringBuilder sb = new StringBuilder();

        //        for( int iCounter = 0 ; iCounter < iIndent ; iCounter++ )
        //        {
        //            sb.Append("    ");
        //        }

        //        Console.Out.Write(sb);
        //    }

        //    Console.Out.WriteLine(strMessage);
        //    Console.ForegroundColor = dfc;
        //}


        ///// <summary>
        ///// Gibt eine Meldung auf der Konsole aus.
        ///// </summary>
        ///// <param name="strMessage">The string message.</param>
        ///// <param name="ccForegroundColor">Color of the cc foreground.</param>
        //public static void Output( string strMessage, ConsoleColor ccForegroundColor ) => Output(strMessage, ccForegroundColor, 0);


        ///// <summary>
        ///// Gibt eine Meldung auf der Konsole aus.
        ///// </summary>
        ///// <param name="strMessage">The string message.</param>
        //public static void Output( string strMessage )
        //{
        //    Console.ForegroundColor = DefaultForegroundColor;

        //    Console.Out.WriteLine(strMessage);
        //}

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private enum BorderLineStyle : byte { Top, Middle, Bottom }


        private sealed class BorderChar
        {
            public char Left;
            public char Middle;
            public char Right;


            public BorderChar( char left, char middle, char right )
            {
                this.Left = left;
                this.Middle = middle;
                this.Right = right;
            }
        }


        private static readonly SortedDictionary<BorderLineStyle, BorderChar> BORDER_CHARS = new()
        {
            { BorderLineStyle.Top, new BorderChar('┌', '┬', '┐') },
            { BorderLineStyle.Middle, new BorderChar('├', '┼', '┤') },
            { BorderLineStyle.Bottom, new BorderChar('└', '┴', '┘') }
        };


        private static void BorderLine( Dictionary<PropertyInfo, int> sdColumnsWidth, BorderLineStyle ls, ConsoleColor border )
        {
            Console.ForegroundColor = border;
            Console.Out.Write(BORDER_CHARS [ls].Left);

            int counter = 0;
            foreach( PropertyInfo pi in sdColumnsWidth.Keys )
            {
                if( counter++ > 0 )
                {
                    Console.Out.Write(BORDER_CHARS [ls].Middle);
                }

                Console.Out.Write(new string('─', sdColumnsWidth [pi] + 2));
            }

            Console.Out.WriteLine(BORDER_CHARS [ls].Right);
        }


        public static void WriteTable<T>( this List<T> lValues, ConsoleColor border = ConsoleColor.Cyan, ConsoleColor header = ConsoleColor.Magenta, ConsoleColor content = ConsoleColor.Yellow )
        {
            if( lValues == null || lValues.Count == 0 )
            {
                return;
            }

            ConsoleColor dfc = Console.ForegroundColor;

            Type t = typeof(T);

            Dictionary<PropertyInfo, int> sdColumnsWidth = new();
            Dictionary<PropertyInfo, string> sdColumnsFormatter = new();

            foreach( PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance) )
            {
                int iMaxWidth = ( from object oItem in lValues where oItem != null select pi.GetValue(oItem, null) into oValue where oValue != null select oValue.ToString().Length ).Concat(new [] { 0 }).Max();

                string strDisplayName = pi.Name;

                if( strDisplayName.Length > iMaxWidth )
                {
                    iMaxWidth = strDisplayName.Length;
                }

                string strFormat = DataTypeHelper.GetTextAligment(pi.PropertyType) == TextAlign.Right ? "{0," + iMaxWidth + "}" : "{0,-" + iMaxWidth + "}";
                sdColumnsWidth.Add(pi, iMaxWidth);
                sdColumnsFormatter.Add(pi, strFormat);
            }

            BorderLine(sdColumnsWidth, BorderLineStyle.Top, border);

            Console.ForegroundColor = border;
            Console.Out.Write("│ ");
            foreach( PropertyInfo pi in sdColumnsFormatter.Keys )
            {
                Console.ForegroundColor = header;
                Console.Out.Write(string.Format(sdColumnsFormatter [pi], pi.Name));

                Console.ForegroundColor = border;
                Console.Out.Write(" │ ");
            }
            Console.Out.WriteLine();

            BorderLine(sdColumnsWidth, BorderLineStyle.Middle, border);

            foreach( object o in lValues )
            {
                if( o != null )
                {
                    Console.ForegroundColor = border;
                    Console.Out.Write("│ ");
                    foreach( PropertyInfo pi in sdColumnsFormatter.Keys )
                    {
                        object value = pi.GetValue(o, null);
                        Console.ForegroundColor = content;
                        Console.Out.Write(string.Format(sdColumnsFormatter [pi], value));

                        Console.ForegroundColor = border;
                        Console.Out.Write(" │ ");
                    }
                    Console.Out.WriteLine();
                }
            }

            BorderLine(sdColumnsWidth, BorderLineStyle.Bottom, border);

            Console.ForegroundColor = dfc;
        }
    }
}
