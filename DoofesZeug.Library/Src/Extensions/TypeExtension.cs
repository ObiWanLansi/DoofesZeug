using System;
using System.Text;



namespace DoofesZeug.Extensions;

public static class TypeExtension
{
    public static string GetTypeName( this Type t, bool bAddGenericType = false )
    {
        string strName = t.Name;

        if( strName == "Nullable`1" )
        {
            return $"{t.GenericTypeArguments [0].Name}?";
        }

        if( t.IsGenericType == false )
        {
            return strName;
        }

        int iIndex = strName.IndexOf('`');

        if( bAddGenericType )
        {
            int iGenericParamCount = t.GetGenericArguments().Length;
            StringBuilder sbGenericName = new(32);
            sbGenericName.AppendFormat("{0}<", iIndex > 0 ? strName.Substring(0, iIndex) : strName);

            for( int iCounter = 0 ; iCounter < iGenericParamCount ; iCounter++ )
            {
                if( iCounter > 0 )
                {
                    sbGenericName.Append(',');
                }

                sbGenericName.AppendFormat("T{0}", iCounter + 1);
            }

            sbGenericName.Append('>');
            return sbGenericName.ToString();
        }

        return strName.Substring(0, iIndex);
    }
}
