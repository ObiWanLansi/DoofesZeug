using System;
using System.Collections.Generic;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Tools.Misc;


[Description("Some functiontions for extended mathematics.")]
public static class MathEx
{
    /// <summary>
    /// The phi constant (Golden Ratio).
    /// </summary>
    public const double Phi = 1.6180339887498948482045868343656381177203091798057628621354486227;

    /// <summary>
    /// The pi constant (Circle Number).
    /// </summary>
    public const double Pi = 3.1415926535897932384626433832795028841971693993751058209749445923;

    /// <summary>
    /// The ratio 4:3.
    /// </summary>
    public const double R4_3 = 4 / (double)3;

    /// <summary>
    /// The ratio 16:9.
    /// </summary>
    public const double R16_9 = 16 / (double)9;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Determines whether this value is a prime number.
    /// </summary>
    /// <param name="iValue">The i value.</param>
    /// <returns>
    ///   <c>true</c> if the specified i value is prime; otherwise, <c>false</c>.
    /// </returns>
    /// <exception cref="ArgumentException">The parameter is less zero.</exception>
    public static bool IsPrime(ulong iValue)
    {
        if (iValue < 0)
        {
            throw new ArgumentException("The parameter is less zero.");
        }

        if (iValue == 0 || iValue == 1)
        {
            return false;
        }

        if (iValue % 2 == 0)
        {
            return false;
        }

        for (ulong iCounter = 3; iCounter < Math.Sqrt(iValue) + 1; iCounter++)
        {
            if (iValue % iCounter == 0)
            {
                return false;
            }
        }

        return true;
    }


    /// <summary>
    /// Gets the prime numbers.
    /// </summary>
    /// <param name="numbercount">The i number count.</param>
    /// <returns></returns>
    public static UnsignedLongList GetPrimeNumbers(uint numbercount)
    {
        UnsignedLongList lValues = new((int)numbercount);

        for (uint iCounter = 0; iCounter < numbercount; iCounter++)
        {
            if (MathEx.IsPrime(iCounter))
            {
                lValues.Add(iCounter);
            }
        }

        return lValues;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the fibonacci list.
    /// </summary>
    /// <param name="iCount">The count of iterations.</param>
    /// <returns></returns>
    public static UnsignedLongList GetFibonacciList(uint iCount)
    {
        if (iCount == 0)
        {
            return [];
        }

        if (iCount == 1)
        {
            return UnsignedLongList.From(0, 1);
        }

        //-----------------------------------------------------------------

        // If we have more than 93 iterations ulong is not big enough !
        if (iCount > 93)
        {
            throw new ArgumentOutOfRangeException(nameof(iCount), "To much counts!");
        }

        //-----------------------------------------------------------------

        ulong[] values = new ulong[iCount + 1];

        values[0] = 0;
        values[1] = 1;

        if (iCount > 1)
        {
            for (int iCounter = 2; iCounter < iCount + 1; iCounter++)
            {
                values[iCounter] = values[iCounter - 1] + values[iCounter - 2];
            }
        }

        return new(values);
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------



    /// <summary>
    /// Gets the random number list.
    /// </summary>
    /// <param name="iNumberCount">The i number count.</param>
    /// <param name="iMinValue">The i minimum value.</param>
    /// <param name="iMaxValue">The i maximum value.</param>
    /// <returns></returns>
    public static IntegerList GetRandomNumberList(int iNumberCount, int iMinValue, int iMaxValue)
    {
        Random r = new();

        IntegerList lValues = new(iNumberCount);

        for (int iCounter = 0; iCounter < iNumberCount; iCounter++)
        {
            // Bei uns ist der MaxValue inklusive ...
            lValues.Add(r.Next(iMinValue, iMaxValue + 1));
        }

        return lValues;
    }


    /// <summary>
    /// Gets the number list.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="stop">The stop.</param>
    /// <param name="step">The step.</param>
    /// <returns></returns>
    public static List<float> GetNumberList(float start, float stop, float step = 1)
    {
        List<float> lValues = new((int)(stop - start));

        for (float fCounter = start; fCounter <= stop; fCounter += step)
        {
            lValues.Add(fCounter);
        }

        return lValues;
    }


    /// <summary>
    /// Gets the number list.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="stop">The stop.</param>
    /// <param name="step">The step.</param>
    /// <returns></returns>
    public static List<double> GetNumberList(double start, double stop, double step = 1)
    {
        List<double> lValues = new((int)(stop - start));

        for (double fCounter = start; fCounter <= stop; fCounter += step)
        {
            lValues.Add(fCounter);
        }

        return lValues;
    }


    /// <summary>
    /// Gets the range number list.
    /// </summary>
    /// <param name="start">The i start.</param>
    /// <param name="stop">The i stop.</param>
    /// <param name="step">The step.</param>
    /// <returns></returns>
    public static IntegerList GetNumberList(int start, int stop, int step = 1)
    {
        IntegerList lValues = new(stop - start);

        for (int iCounter = start; iCounter <= stop; iCounter += step)
        {
            lValues.Add(iCounter);
        }

        return lValues;
    }


    /// <summary>
    /// Gets the ordered number list.
    /// </summary>
    /// <param name="iNumberCount">The i number count.</param>
    /// <returns></returns>
    public static IntegerList GetNumberList(int iNumberCount)
    {
        IntegerList lValues = new(iNumberCount);

        for (int iCounter = 0; iCounter < iNumberCount; iCounter++)
        {
            lValues.Add(iCounter);
        }

        return lValues;
    }
}
