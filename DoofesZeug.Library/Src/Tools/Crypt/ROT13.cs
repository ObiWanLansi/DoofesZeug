using System;
using System.Text;



namespace DoofesZeug.Tools.Crypt
{
    public static class ROT13
    {
        public static string Rotate( string strContent )
        {
            StringBuilder sb = new(strContent.Length);

            foreach( char bASCII in strContent.ToUpper() )
            {
                if( Char.IsLetter(bASCII) )
                {
                    byte bAlphabet = (byte) ( bASCII - 65 );

                    bAlphabet = (byte) ( ( bAlphabet + 13 ) % 26 );

                    sb.Append((char) ( bAlphabet + 65 ));
                }
                else
                {
                    if( bASCII == 32 )
                    {
                        sb.Append((char) 32);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
