using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using DoofesZeug.Tools.Enums;
using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Extensions
{
    public static class StringOutputExtension
    {
        public static string ToStringTable( this object value, bool bSortByName = false, bool bDisplayNULL = false )
        {
            Type type = value.GetType();

            List<PropertyInfo> properties = new(type.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public));

            if( bSortByName == true )
            {
                properties.Sort(( x, y ) => x.Name.CompareTo(y.Name));
            }

            // |Name|Value|
            int [] columnWidths = new int [2] { "Property".Length, "Value".Length };

            foreach( PropertyInfo pi in properties )
            {
                if( pi.Name.Length > columnWidths [0] )
                {
                    columnWidths [0] = pi.Name.Length;
                }

                int iPropertyValueStringLength = $"{pi.GetValue(value)}".Length;

                if( iPropertyValueStringLength > columnWidths [1] )
                {
                    columnWidths [1] = iPropertyValueStringLength;
                }
            }

            columnWidths [0] = columnWidths [0] + 2;
            columnWidths [1] = columnWidths [1] + 2;

            string strColumn0Format = "{0,-" + columnWidths [0] + "}";
            string strColumn1Format = "{0,-" + columnWidths [1] + "}";

            StringBuilder sb = new(512);

            //sb.AppendLine($"{type.FullName}:");
            sb.AppendLine("┌" + new string('─', columnWidths [0]) + "┬" + new string('─', columnWidths [1]) + "┐");
            sb.AppendFormat("│{0}│{1}│", string.Format(strColumn0Format, " Property"), string.Format(strColumn1Format, " Value"));
            sb.AppendLine();
            sb.AppendLine("├" + new string('─', columnWidths [0]) + "┼" + new string('─', columnWidths [1]) + "┤");

            foreach( PropertyInfo pi in properties )
            {
                object piValue = pi.GetValue(value);

                if( bDisplayNULL == true && piValue == null )
                {
                    piValue = "NULL";
                }

                sb.AppendFormat("│{0}│{1}│", string.Format(strColumn0Format, " " + pi.Name), string.Format(strColumn1Format, $" {piValue}"));
                sb.AppendLine();
            }

            sb.AppendLine("└" + new string('─', columnWidths [0]) + "┴" + new string('─', columnWidths [1]) + "┘");

            return sb.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public static string ToStringTable<T>( this List<T> lValues, bool bShowColumnType = false )
        {
            if( lValues == null || lValues.Count == 0 )
            {
                return null;
            }

            StringBuilder sbOutput = new(8192);

            //-------------------------------------------------------------------------------------

            Dictionary<PropertyInfo, string> sdColumnsWidth = new();

            Type t = typeof(T);

            int iColumnCounter = 0;

            StringBuilder sbBorderTop = new(64);
            StringBuilder sbBorderMiddle = new(64);
            StringBuilder sbBorderBottom = new(64);
            StringBuilder sbHeader = new(64);

            sbBorderTop.Append('┌');
            sbBorderMiddle.Append('├');
            sbBorderBottom.Append('└');

            foreach( PropertyInfo pi in t.GetProperties(BindingFlags.Public | BindingFlags.GetProperty | BindingFlags.Instance) )
            {
                int iMaxWidth = ( from object oItem in lValues where oItem != null select pi.GetValue(oItem, null) into oValue where oValue != null select oValue.ToString().Length ).Concat(new [] { 0 }).Max();

                string strDisplayName = pi.Name;

                if( bShowColumnType == true )
                {
                    strDisplayName += $" ({pi.PropertyType.GetTypeName()})";
                }

                if( strDisplayName.Length > iMaxWidth )
                {
                    iMaxWidth = strDisplayName.Length;
                }

                string strFormat = DataTypeHelper.GetTextAligment(pi.PropertyType) == TextAlign.Right ? "│ {0," + iMaxWidth + "} " : "│ {0,-" + iMaxWidth + "} ";
                sdColumnsWidth.Add(pi, strFormat);

                if( iColumnCounter > 0 )
                {
                    sbBorderTop.Append('┬');
                    sbBorderMiddle.Append('┼');
                    sbBorderBottom.Append('┴');
                }

                string strLine = new('─', iMaxWidth + 2);

                sbBorderTop.Append(strLine);
                sbBorderMiddle.Append(strLine);
                sbBorderBottom.Append(strLine);

                sbHeader.AppendFormat(strFormat, strDisplayName);

                iColumnCounter++;
            }

            sbHeader.Append('│');
            sbBorderTop.Append('┐');
            sbBorderMiddle.Append('┤');
            sbBorderBottom.Append('┘');

            sbOutput.AppendLine(sbBorderTop.ToString());
            sbOutput.AppendLine(sbHeader.ToString());
            sbOutput.AppendLine(sbBorderMiddle.ToString());

            foreach( object o in lValues )
            {
                if( o != null )
                {
                    foreach( PropertyInfo pi in sdColumnsWidth.Keys )
                    {
                        sbOutput.AppendFormat(sdColumnsWidth [pi], pi.GetValue(o, null));
                    }

                    sbOutput.AppendLine("│");
                }
                else
                {
                    sbOutput.AppendLine(sbBorderMiddle.ToString());
                }
            }

            sbOutput.AppendLine(sbBorderBottom.ToString());

            //-------------------------------------------------------------------------------------

            return sbOutput.ToString();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // public static string ToStringTree<K, V>( this SortedDictionary<K, V> dict )


        public static string ToStringTree<K, V>( this SortedDictionary<K, List<V>> dict )
        {
            if( dict == null || dict.Count == 0 )
            {
                return null;
            }

            StringBuilder sbOutput = new(8192);

            //-------------------------------------------------------------------------------------

            int countDict = dict.Count;
            int counterDict = 0;

            using( IEnumerator<K> key = dict.Keys.GetEnumerator() )
            {
                while( key.MoveNext() )
                {
                    string strKey = $"{key.Current}";

                    if( counterDict < countDict - 1 )
                    {
                        sbOutput.Append("├───");
                    }
                    else
                    {
                        sbOutput.Append("└───");
                    }

                    sbOutput.AppendLine(strKey);

                    List<V> list = dict [key.Current];

                    int countList = list.Count;
                    int counterList = 0;

                    foreach( V item in list )
                    {
                        if( counterList < countList - 1 )
                        {
                            if( counterDict < countDict - 1 )
                            {
                                sbOutput.Append("│    ├───");
                            }
                            else
                            {
                                sbOutput.Append("     ├───");
                            }
                        }
                        else
                        {
                            if( counterDict < countDict - 1 )
                            {
                                sbOutput.Append("│    └───");
                            }
                            else
                            {
                                sbOutput.Append("     └───");
                            }
                        }

                        sbOutput.AppendLine($" {item}");
                        counterList++;
                    }

                    counterDict++;
                }
            }

            //-------------------------------------------------------------------------------------

            return sbOutput.ToString();
        }
    }
}
