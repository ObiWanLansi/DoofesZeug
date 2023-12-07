using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

using DoofesZeug.Extensions;



namespace DoofesZeug.Tools.Crypt;

/// <summary>
/// Hilfsklasse für die Berechnung von Prüfsummen (MD5, SHA1).
/// </summary>
public static class SimpleHash
{
    private static readonly SortedDictionary<SupportedHashAlgorithm, HashAlgorithm> HASHALGORITHMS = new()
    {
        { SupportedHashAlgorithm.MD5, new MD5CryptoServiceProvider() },
        { SupportedHashAlgorithm.SHA1, new SHA1CryptoServiceProvider() },
        { SupportedHashAlgorithm.SHA256, new SHA256CryptoServiceProvider() },
        { SupportedHashAlgorithm.SHA512, new SHA512CryptoServiceProvider() }
    };


    /// <summary>
    /// Gets the hash.
    /// </summary>
    /// <param name="strText">The string text.</param>
    /// <param name="sha">The sha.</param>
    /// <param name="strSalt">The string salt.</param>
    /// <returns></returns>
    public static string GetHash(string strText, SupportedHashAlgorithm sha, string strSalt = null)
    {
        byte[] bHash = HASHALGORITHMS[sha].ComputeHash(Encoding.Default.GetBytes(strSalt.IsNotEmpty() ? strText + strSalt : strText));

        StringBuilder sb = new(64);

        foreach (byte b in bHash)
        {
            _ = sb.AppendFormat("{0:X2}", b);
        }

        return sb.ToString();
    }


    /// <summary>
    /// Gets the hash.
    /// </summary>
    /// <param name="fi">The fi.</param>
    /// <param name="sha">The sha.</param>
    /// <returns></returns>
    public static string GetFileHash(string fullfilename, SupportedHashAlgorithm sha)
    {
        HashAlgorithm ha = HASHALGORITHMS[sha];
        StringBuilder sbHash = new(64);

        using FileStream fs = new(fullfilename, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);

        foreach (byte b in ha.ComputeHash(fs))
        {
            sbHash.AppendFormat("{0:X2}", b);
        }

        return sbHash.ToString();
    }
}
