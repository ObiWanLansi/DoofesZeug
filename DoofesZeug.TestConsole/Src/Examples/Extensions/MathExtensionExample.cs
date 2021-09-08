﻿using System;

using DoofesZeug.Datatypes.Container;
using DoofesZeug.Extensions;



namespace DoofesZeug.Examples.Extensions
{
    public static class MathExtensionExample
    {
        public static void GetFibonacciList()
        {
            for( uint counter = 0 ; counter < 90 ; counter++ )
            {
                UnsignedLongList list = counter.GetFibonacciList();
                
                Console.Out.WriteLineAsync();
                Console.Out.WriteLineAsync($"{counter:d2}: {list.ToFlatString()}");
            }
        }
    }
}
