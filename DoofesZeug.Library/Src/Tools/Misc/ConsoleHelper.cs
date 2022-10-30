using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading;

using DoofesZeug.Extensions;
using DoofesZeug.Tools.Enums;



namespace DoofesZeug.Tools.Misc
{
    public static class ConsoleHelper
    {
        /// <summary>
        /// Just wait for a key.
        /// </summary>
        public static void Getch() => Console.ReadKey(true);


        /// <summary>
        /// Just wait for a specified key.
        /// </summary>
        /// <param name="ck">The ck.</param>
        public static void Getch(ConsoleKey ck)
        {
            do
            {
                while (Console.KeyAvailable == false)
                {
                    Thread.Sleep(50);
                }
            }
            while (Console.ReadKey(true).Key != ck);
        }


        /// <summary>
        /// Display an optional text and wait for any key.
        /// </summary>
        /// <param name="strMessage">The Message to display, can be null.</param>
        public static void Getch(string strMessage)
        {
            if (strMessage.IsNotEmpty())
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
        public static void Getch(ConsoleKey ck, string strMessage)
        {
            if (strMessage.IsNotEmpty())
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


        private enum BorderLineStyle : byte { Top, Middle, Bottom }


        private sealed class BorderChar
        {
            public char Left;
            public char Middle;
            public char Right;


            public BorderChar(char left, char middle, char right)
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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void BorderLine(Dictionary<PropertyInfo, int> sdColumnsWidth, BorderLineStyle ls, ConsoleColor border)
        {
            Console.ForegroundColor = border;
            Console.Out.Write(BORDER_CHARS[ls].Left);

            int counter = 0;

            foreach (PropertyInfo pi in sdColumnsWidth.Keys)
            {
                if (counter++ > 0)
                {
                    Console.Out.Write(BORDER_CHARS[ls].Middle);
                }

                Console.Out.Write(new string('─', sdColumnsWidth[pi] + 2));
            }

            Console.Out.WriteLine(BORDER_CHARS[ls].Right);
        }


        /// <summary>
        /// Writes the table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lValues">The l values.</param>
        /// <param name="border">The border.</param>
        /// <param name="header">The header.</param>
        /// <param name="content">The content.</param>
        /// <param name="color_resolver">The color resolver.</param>
        public static void WriteTable<T>(List<T> lValues, ConsoleColor border = ConsoleColor.Cyan, ConsoleColor header = ConsoleColor.Magenta, ConsoleColor content = ConsoleColor.Yellow, Func<T, ConsoleColor> color_resolver = null)
        {
            if (lValues == null || lValues.Count == 0)
            {
                return;
            }

            ConsoleColor dfc = Console.ForegroundColor;

            //---------------------------------------------------------------------------------------------------------

            Type t = typeof(T);

            Dictionary<PropertyInfo, int> sdColumnsWidth = new();
            Dictionary<PropertyInfo, string> sdColumnsFormatter = new();

            foreach (PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance))
            {
                IEnumerable<int> widths = (from object oItem in lValues where oItem != null select pi.GetValue(oItem, null) into oValue where oValue != null select oValue.ToString().Length);
                int iMaxWidth = widths.Any() ? widths.Max() : 0;

                if (pi.Name.Length > iMaxWidth)
                {
                    iMaxWidth = pi.Name.Length;
                }

                string strFormat = DataTypeHelper.GetTextAligment(pi.PropertyType) == TextAlign.Right ? "{0," + iMaxWidth + "}" : "{0,-" + iMaxWidth + "}";
                sdColumnsWidth.Add(pi, iMaxWidth);
                sdColumnsFormatter.Add(pi, strFormat);
            }

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Top, border);

            //---------------------------------------------------------------------------------------------------------

            // Header

            Console.ForegroundColor = border;
            Console.Out.Write("│ ");
            foreach (PropertyInfo pi in sdColumnsFormatter.Keys)
            {
                Console.ForegroundColor = header;
                Console.Out.Write(string.Format(sdColumnsFormatter[pi], pi.Name));

                Console.ForegroundColor = border;
                Console.Out.Write(" │ ");
            }
            Console.Out.WriteLine();

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Middle, border);

            //---------------------------------------------------------------------------------------------------------

            // Data

            foreach (object o in lValues)
            {
                if (o != null)
                {
                    Console.ForegroundColor = border;
                    Console.Out.Write("│ ");

                    foreach (PropertyInfo pi in sdColumnsFormatter.Keys)
                    {
                        object value = pi.GetValue(o, null);

                        Console.ForegroundColor = color_resolver != null ? color_resolver((T)o) : content;
                        Console.Out.Write(string.Format(sdColumnsFormatter[pi], value));

                        Console.ForegroundColor = border;
                        Console.Out.Write(" │ ");
                    }

                    Console.Out.WriteLine();
                }
            }

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Bottom, border);

            //---------------------------------------------------------------------------------------------------------

            Console.ForegroundColor = dfc;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        private static void BorderLine(Dictionary<DataColumn, int> sdColumnsWidth, BorderLineStyle ls, ConsoleColor border)
        {
            Console.ForegroundColor = border;
            Console.Out.Write(BORDER_CHARS[ls].Left);

            int counter = 0;

            foreach (DataColumn pi in sdColumnsWidth.Keys)
            {
                if (counter++ > 0)
                {
                    Console.Out.Write(BORDER_CHARS[ls].Middle);
                }

                Console.Out.Write(new string('─', sdColumnsWidth[pi] + 2));
            }

            Console.Out.WriteLine(BORDER_CHARS[ls].Right);
        }


        /// <summary>
        /// Writes the table.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="border">The border.</param>
        /// <param name="header">The header.</param>
        /// <param name="content">The content.</param>
        /// <param name="color_resolver">The color resolver.</param>
        public static void WriteTable(DataTable dt, ConsoleColor border = ConsoleColor.Cyan, ConsoleColor header = ConsoleColor.Magenta, ConsoleColor content = ConsoleColor.Yellow, Func<DataRow, ConsoleColor> color_resolver = null)
        {
            if (dt == null || dt.Columns.Count == 0 || dt.Rows.Count == 0)
            {
                return;
            }

            ConsoleColor dfc = Console.ForegroundColor;

            //---------------------------------------------------------------------------------------------------------

            Dictionary<DataColumn, int> sdColumnsWidth = new();
            Dictionary<DataColumn, string> sdColumnsFormatter = new();

            foreach (DataColumn dc in dt.Columns)
            {
                int iMaxWidth = dc.ColumnName.Length;

                foreach (DataRow dr in dt.Rows)
                {
                    object o = dr[dc.Ordinal];
                    int iLength = o != DBNull.Value && o != null ? $"{o}".Length : 0;

                    if (iLength > iMaxWidth)
                    {
                        iMaxWidth = iLength;
                    }
                }

                string strFormat = DataTypeHelper.GetTextAligment(dc.DataType) == TextAlign.Right ? "{0," + iMaxWidth + "}" : "{0,-" + iMaxWidth + "}";
                sdColumnsWidth.Add(dc, iMaxWidth);
                sdColumnsFormatter.Add(dc, strFormat);
            }

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Top, border);

            //---------------------------------------------------------------------------------------------------------

            // Header

            Console.ForegroundColor = border;
            Console.Out.Write("│ ");
            foreach (DataColumn dc in dt.Columns)
            {
                Console.ForegroundColor = header;
                Console.Out.Write(string.Format(sdColumnsFormatter[dc], dc.ColumnName));

                Console.ForegroundColor = border;
                Console.Out.Write(" │ ");
            }
            Console.Out.WriteLine();

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Middle, border);

            //---------------------------------------------------------------------------------------------------------

            // Data

            foreach (DataRow row in dt.Rows)
            {
                Console.ForegroundColor = border;
                Console.Out.Write("│ ");

                foreach (DataColumn dc in sdColumnsFormatter.Keys)
                {
                    object value = row[dc];

                    Console.ForegroundColor = color_resolver != null ? color_resolver(row) : content;
                    Console.Out.Write(string.Format(sdColumnsFormatter[dc], value));

                    Console.ForegroundColor = border;
                    Console.Out.Write(" │ ");
                }

                Console.Out.WriteLine();
            }

            //---------------------------------------------------------------------------------------------------------

            BorderLine(sdColumnsWidth, BorderLineStyle.Bottom, border);

            //---------------------------------------------------------------------------------------------------------

            Console.ForegroundColor = dfc;
        }
    }
}
