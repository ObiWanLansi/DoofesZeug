using System.Text;



namespace DoofesZeug.Extensions;

public static class StringBuilderExtension
{
    /// <summary>
    /// Appends the line.
    /// </summary>
    /// <param name="sb">The sb.</param>
    /// <param name="strFormat">The string format.</param>
    /// <param name="param">The parameter.</param>
    public static void AppendLine( this StringBuilder sb, string strFormat, params object [] param )
    {
        sb.AppendFormat(strFormat, param);
        sb.AppendLine();
    }


    /// <summary>
    /// Appends the objects.
    /// </summary>
    /// <param name="sb">The sb.</param>
    /// <param name="cSeperator">The c seperator.</param>
    /// <param name="param">The parameter.</param>
    public static void AppendObjectsWithSeperatorLine( this StringBuilder sb, char cSeperator, params object [] param )
    {
        foreach( object value in param )
        {
            sb.Append(cSeperator);
            sb.Append(value);
        }
        sb.Append(cSeperator);
        sb.AppendLine();
    }
}
