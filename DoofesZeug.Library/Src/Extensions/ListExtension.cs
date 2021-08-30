using System.Collections.Generic;
using System.Text;



namespace DoofesZeug.Extensions
{
    public static class ListExtension
    {
        public static string ToFlatString<T>( this List<T> lValues, string strDivider = ", " )
        {
            StringBuilder sbFlatten = new StringBuilder(128);
            for( int iCounter = 0 ; iCounter < lValues.Count ; iCounter++ )
            {
                if( iCounter > 0 )
                {
                    sbFlatten.Append(strDivider);
                }
                sbFlatten.Append(lValues [iCounter]);
            }
            return sbFlatten.ToString();
        }
    }
}