using System.Text;



namespace DoofesZeug.Tools.Crypt;

public static class ROT128
{
    public static string Rotate( string strContent )
    {
        StringBuilder sb = new(strContent.Length);

        foreach( char bASCII in strContent.ToUpper() )
        {
            byte b = (byte) bASCII;
            b += 128;
            sb.Append((char) b);
        }

        return sb.ToString();
    }
}
