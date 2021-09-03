using System.Collections.Generic;
using System.Text;



namespace DoofesZeug.Extensions
{
    public static class ListExtension
    {
        public static string ToFlatString<T>( this List<T> values, string strDivider = ", " )
        {
            StringBuilder sbFlatten = new(128);
            for( int iCounter = 0 ; iCounter < values.Count ; iCounter++ )
            {
                if( iCounter > 0 )
                {
                    sbFlatten.Append(strDivider);
                }
                sbFlatten.Append(values [iCounter]);
            }
            return sbFlatten.ToString();
        }
    }
}