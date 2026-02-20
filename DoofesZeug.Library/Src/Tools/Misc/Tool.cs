using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Tools.Misc;

[Description("An static class with some static standalone methods or constants.")]
public static class Tool
{
    /// <summary>
    /// Franz jagt im komplett verwahrlosten Taxi quer durch Bayern.
    /// </summary>
    public static readonly string FRANZ = "Franz jagt im komplett verwahrlosten Taxi quer durch Bayern.";

    /// <summary>
    /// The quick brown fox jumps over a lazy dog.
    /// </summary>
    public static readonly string FOX = "The quick brown fox jumps over a lazy dog.";

    /// <summary>
    /// Vom Ödipuskomplex maßlos gequält, übt Wilfried zyklisches Jodeln.
    /// </summary>
    public static readonly string WILFRIED = "Vom Ödipuskomplex maßlos gequält, übt Wilfried zyklisches Jodeln.";

    /// <summary>
    /// Falsches Üben von Xylophonmusik quält jeden größeren Zwerg.
    /// </summary>
    public static readonly string XYLOPHONMUSIK = "Falsches Üben von Xylophonmusik quält jeden größeren Zwerg.";

    /// <summary>
    /// The allchars
    /// </summary>
    public static readonly string ALLCHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZÖÄÜabcdefghijklmnopqrstuvwxyzöäü0123456789/*-+!\"§$%&()=?,.;:@€µ#'´`<>|^°\\";

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the size of the human readable.
    /// </summary>
    /// <param name="lSize">Size of the l.</param>
    /// <returns></returns>
    public static string GetHumanReadableSize(long lSize)
    {
        if (lSize >= 1099511627776)
        {
            return $"{(float)lSize / 1099511627776:F} Tb";
        }

        if (lSize >= 1073741824)
        {
            return $"{(float)lSize / 1073741824:F} Gb";
        }

        if (lSize >= 1048576)
        {
            return $"{(float)lSize / 1048576:F} Mb";
        }

        if (lSize >= 1024)
        {
            return $"{(float)lSize / 1024:F} Kb";
        }

        return lSize + " Bytes";
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// The datetimeformats
    /// </summary>
    public static readonly string[] DATETIMEFORMATS =
    [
        "dd.MM.yyyy, HH:mm:ss" ,
        "dd.MM.yyyy HH:mm:ss" ,
        "dd.MM.yyyy, HH:mm" ,
        "dd.MM.yyyy HH:mm" ,
        "dd.MM.yyyy" ,
        "ddMMyyyy_HHmmss" ,
        "yyyyMMdd_HHmmss" ,
        "yyyy-MM-dd" ,
        "dd-MM-yyyy",
        "yyyy-MM-dd HH:mm:ss"
    ];

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Enums to list.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentException">tEnum</exception>
    public static List<T> EnumToList<T>()
    {
        Type tEnum = typeof(T);

        return tEnum.IsEnum == false ? throw new ArgumentException(nameof(tEnum)) : [.. Enum.GetValues(tEnum).Cast<T>()];
    }


    /// <summary>
    /// Enums to string list.
    /// </summary>
    /// <param name="tEnum">The t enum.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">tEnum</exception>
    public static StringList EnumToStringList(Type tEnum)
    {
        return tEnum.IsEnum == false ? throw new ArgumentException($"The type '{tEnum.FullName}' is not an enumeration!", nameof(tEnum)) : [.. Enum.GetNames(tEnum)];
    }


    /// <summary>
    /// Alls this instance.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="System.ArgumentException">tEnum</exception>
    public static T All<T>()
    {
        Type tEnum = typeof(T);

        if (tEnum.IsEnum == false)
        {
            throw new ArgumentException(nameof(tEnum));
        }

        int iResult = 0;

        foreach (object value in Enum.GetValues(tEnum))
        {
            iResult |= Convert.ToInt32(value);
        }

        return (T)Enum.ToObject(tEnum, iResult);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Numbers to roman.
    /// </summary>
    /// <param name="uValue">The u value.</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException">Die Zahl ist zu groß um als römische Zahl darstellen zu können!</exception>
    /// <exception cref="ArgumentException">Die Zahl ist zu groß um als römische Zahl darstellen zu können!</exception>
    public static string NumberToRoman(ushort uValue)
    {
        if (uValue > 3999)
        {
            throw new ArgumentException("Die Zahl ist zu groß um als römische Zahl darstellen zu können!");
        }

        if (uValue == 0)
        {
            return string.Empty;
        }

        StringBuilder sb = new(8);

        SortedDictionary<ushort, string> mapping = new()
        {
            { 1, "I" },
            { 4, "IV" },
            { 5, "V" },
            { 9, "IX" },
            { 10, "X" },
            { 40, "XL" },
            { 50, "L" },
            { 90, "XC" },
            { 100, "C" },
            { 400, "CD" },
            { 500, "D" },
            { 900, "CM" },
            { 1000, "M" },
        };

        foreach (KeyValuePair<ushort, string> kvp in mapping.Reverse())
        {
            while (uValue >= kvp.Key)
            {
                uValue -= kvp.Key;
                sb.Append(kvp.Value);
            }
        }

        return sb.ToString();
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the size.
    /// </summary>
    /// <param name="strSize">Size of the STR.</param>
    /// <param name="lDefault">The l default.</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException">Die Einheit Tb wird nicht unterstützt!</exception>
    public static long GetSize(string strSize, long lDefault)
    {
        if (string.IsNullOrEmpty(strSize))
        {
            return lDefault;
        }

        StringBuilder sbDigits = new(3);
        StringBuilder sbFactor = new(2);

        foreach (char c in strSize.Trim().ToLower())
        {
            if (char.IsDigit(c))
            {
                sbDigits.Append(c);
            }
            else
            {
                if (char.IsLetter(c))
                {
                    sbFactor.Append(c);
                }
            }
        }

        // Wenn eine Exception auftritt, geben wir diese ersteinmal weiter ...
        long lValue = long.Parse(sbDigits.ToString());

        return sbFactor.ToString() switch
        {
            "tb" => throw new NotSupportedException("Die Einheit Tb wird nicht unterstützt!"),
            "gb" => lValue * 1024 * 1024 * 1024,
            "mb" => lValue * 1024 * 1024,
            "kb" => lValue * 1024,
            "b" => lValue,
            _ => lDefault,
        };
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the uptime.
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetUptime() => TimeSpan.FromMilliseconds(Environment.TickCount);


    /// <summary>
    /// Returns an new guid as string.
    /// </summary>
    /// <returns></returns>
    public static string GUID() => Guid.NewGuid().ToString();


    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Determines whether the URL is reachable.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>
    ///   <c>true</c> if the URL is reachable; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsUrlReachable(string url)
    {
        using HttpClientHandler hch = new()
        {
            UseProxy = true,
            Proxy = WebRequest.DefaultWebProxy,
            DefaultProxyCredentials = CredentialCache.DefaultCredentials,
            CheckCertificateRevocationList = true,
        };

        using HttpClient hc = new(hch);

        using Task<HttpResponseMessage> task = hc.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        task.Wait();

        using HttpResponseMessage response = task.Result;

        return response.StatusCode == HttpStatusCode.OK;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    //private static readonly ConsoleColor DEFAULT_FOREGROUND = Console.ForegroundColor;


    //public static void Print( string strContent, ConsoleColor? foreground )
    //{
    //    if( foreground.HasValue )
    //    {
    //        Console.ForegroundColor = foreground.Value;
    //        Console.Out.WriteLineAsync(strContent);
    //        Console.ForegroundColor = DEFAULT_FOREGROUND;
    //        return;
    //    }

    //    Console.Out.WriteLineAsync(strContent);
    //}


    //public static void PrintError( string strContent )
    //{
    //    Console.ForegroundColor = ConsoleColor.Red;
    //    Console.Error.WriteLineAsync(strContent);
    //    Console.ForegroundColor = DEFAULT_FOREGROUND;
    //}

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Simples the match.
    /// </summary>
    /// <param name="strContent">Content of the string.</param>
    /// <param name="strSearchText">The string search text.</param>
    /// <returns></returns>
    public static bool SimpleMatch(string strContent, string strSearchText)
    {
        if (strSearchText.Equals("*"))
        {
            return true;
        }

        if (strSearchText.StartsWith("*") && strSearchText.EndsWith("*"))
        {
            strSearchText = strSearchText.Substring(1, strSearchText.Length - 2);
            return strContent.Contains(strSearchText);
        }

        if (strSearchText.StartsWith("*"))
        {
            strSearchText = strSearchText.Substring(1, strSearchText.Length - 1);
            return strContent.EndsWith(strSearchText);
        }

        if (strSearchText.EndsWith("*"))
        {
            strSearchText = strSearchText.Substring(0, strSearchText.Length - 1);
            return strContent.StartsWith(strSearchText);
        }

        return strContent.Equals(strSearchText);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the block.
    /// </summary>
    /// <param name="iValue">The i value.</param>
    /// <returns></returns>
    public static (int, int) GetBlock(int iValue)
    {
        double dSqrt = Math.Sqrt(iValue);

        int iBlockOne = (int)Math.Round(dSqrt);

        if (dSqrt == iBlockOne)
        {
            return ((int)dSqrt, (int)dSqrt);
        }

        for (int iCounter = iBlockOne; iCounter > 0; iCounter--)
        {
            double dResult = (double)iValue / (double)iCounter;

            if (dResult == Math.Round(dResult))
            {
                return (iCounter, (int)dResult);
            }
        }

        return (-1, -1);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Combines the specified lists.
    /// </summary>
    /// <param name="lists">The lists.</param>
    /// <returns></returns>
    public static IEnumerable<object[]> Combine(params IList[] lists)
    {
        int iTotalCount = 1;
        int[] iColumnLength = new int[lists.Length];
        int[] iColumnChanges = new int[lists.Length];

        {
            int iColumn = 0;
            int iPreChange = 1;

            foreach (IList list in lists)
            {
                iPreChange *= list.Count;

                iColumnChanges[iColumn] = iPreChange;
                iColumnLength[iColumn] = list.Count;

                iTotalCount *= list.Count;

                iColumn++;
            }
        }

        for (int iColumn = 0; iColumn < lists.Length; iColumn++)
        {
            iColumnChanges[iColumn] = iTotalCount / iColumnChanges[iColumn];
        }

        for (int iRow = 0; iRow < iTotalCount; iRow++)
        {
            object[] row = new object[lists.Length];

            int iColumn = 0;

            foreach (IList list in lists)
            {
                row[iColumn] = list[iRow / iColumnChanges[iColumn] % iColumnLength[iColumn]];
                iColumn++;
            }

            yield return row;
        }
    }
}
