using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;



namespace DoofesZeug.Tools.Crypt
{
    public static class AES
    {
        private static readonly int ITERATIONS = 12345;


        /// <summary>
        /// Encrypts the specified string plain text.
        /// </summary>
        /// <param name="strPlainText">The string plain text.</param>
        /// <param name="strPassword">The string password.</param>
        /// <returns></returns>
        public static string Encrypt( string strPlainText, string strPassword, string Salt )
        {
            byte [] encryptedBytes;
            byte [] plainBytes = Encoding.Unicode.GetBytes(strPlainText);

            using( Aes aes = Aes.Create() )
            {
                using( Rfc2898DeriveBytes pbkdf2 = new(strPassword, Encoding.Unicode.GetBytes(Salt), ITERATIONS) )
                {
                    aes.Key = pbkdf2.GetBytes(32);
                    aes.IV = pbkdf2.GetBytes(16);

                    using( MemoryStream ms = new() )
                    {
                        using( CryptoStream cs = new(ms, aes.CreateEncryptor(), CryptoStreamMode.Write) )
                        {
                            cs.Write(plainBytes, 0, plainBytes.Length);
                        }

                        encryptedBytes = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }


        /// <summary>
        /// Decrypts the specified string crypted text.
        /// </summary>
        /// <param name="strCryptedText">The string crypted text.</param>
        /// <param name="strPassword">The string password.</param>
        /// <returns></returns>
        public static string Decrypt( string strCryptedText, string strPassword, string Salt )
        {
            byte [] plainBytes;
            byte [] cryptoBytes = Convert.FromBase64String(strCryptedText);

            using( Aes aes = Aes.Create() )
            {
                using( Rfc2898DeriveBytes pbkdf2 = new(strPassword, Encoding.Unicode.GetBytes(Salt), ITERATIONS) )
                {
                    aes.Key = pbkdf2.GetBytes(32);
                    aes.IV = pbkdf2.GetBytes(16);

                    using( MemoryStream ms = new() )
                    {
                        using( CryptoStream cs = new(ms, aes.CreateDecryptor(), CryptoStreamMode.Write) )
                        {
                            cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                        }

                        plainBytes = ms.ToArray();
                    }
                }
            }

            return Encoding.Unicode.GetString(plainBytes);
        }
    }
}
