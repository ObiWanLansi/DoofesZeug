using System;

using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Examples.Tools;

public static class LoremIpsumExample
{
    public static void CreateLoremIpsum()
    {
        string strLoremIpsum = LoremIpsum.GetLoremIpsum();

        Console.Out.WriteLineAsync(strLoremIpsum);
    }
}