using System;
using System.Reflection;
using System.Text;



namespace DoofesZeug.Extensions
{
    public static class StringOutputExtension
    {
        public static string ToStringTable( this object value )
        {
            Type type = value.GetType();

            PropertyInfo [] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.Public);

            int [] columnWidths = new int [properties.Length];

            foreach( PropertyInfo pi in properties )
            {
                string strPropertyValueString = $"{pi.GetValue(value)}";
                int iPropertyValueString = strPropertyValueString.Length;

            }

            StringBuilder sb = new(512);

            return sb.ToString();
        }
    }
}
