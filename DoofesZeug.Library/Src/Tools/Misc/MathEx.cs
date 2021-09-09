using System;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Tools.Misc
{

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
        /// Determines whether this value is a prime number.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        ///   <c>true</c> if the specified i value is prime; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">The parameter is less zero.</exception>
        public static bool IsPrime( int iValue )
        {
            if( iValue < 0 )
            {
                throw new ArgumentException("The parameter is less zero.");
            }

            if( iValue == 0 || iValue == 1 )
            {
                return false;
            }

            if( iValue % 2 == 0 )
            {
                return false;
            }

            for( int iCounter = 3 ; iCounter < Math.Sqrt(iValue) + 1 ; iCounter++ )
            {
                if( iValue % iCounter == 0 )
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Gets the fibonacci list.
        /// </summary>
        /// <param name="iCount">The count of iterations.</param>
        /// <returns></returns>
        public static UnsignedLongList GetFibonacciList( uint iCount )
        {
            if( iCount == 0 )
            {
                return new();
            }

            if( iCount == 1 )
            {
                return UnsignedLongList.From(0, 1);
            }

            //-----------------------------------------------------------------

            // If we have more than 93 iterations ulong is not big enough !
            if( iCount > 93 )
            {
                throw new ArgumentOutOfRangeException(nameof(iCount), "To much counts!");
            }

            //-----------------------------------------------------------------

            ulong [] values = new ulong [iCount + 1];

            values [0] = 0;
            values [1] = 1;

            if( iCount > 1 )
            {
                for( int iCounter = 2 ; iCounter < iCount + 1 ; iCounter++ )
                {
                    values [iCounter] = values [iCounter - 1] + values [iCounter - 2];
                }
            }

            return new(values);
        }
    }
}
