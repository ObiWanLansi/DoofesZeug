﻿using System;

using DoofesZeug.Datatypes.Container;
using DoofesZeug.Extensions;
using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Examples.Extensions;

public static class MathExExample
{
    public static void GetFibonacciList()
    {
        for( uint counter = 0 ; counter < 90 ; counter++ )
        {
            UnsignedLongList list = MathEx.GetFibonacciList(counter);

            Console.Out.WriteLineAsync();
            Console.Out.WriteLineAsync($"{counter:d2}: {list.ToFlatString()}");
        }
    }

    public static void CheckPrimeNumber()
    {
        ulong value = 42;
        Console.Out.WriteLineAsync($"{value}: {MathEx.IsPrime(value)}");
    }
}
