using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;



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
    }
}
