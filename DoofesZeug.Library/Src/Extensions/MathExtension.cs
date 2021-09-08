using System;

using DoofesZeug.Datatypes.Container;

namespace DoofesZeug.Extensions
{
    public static class MathExtension
    {
        /// <summary>
        /// Determines whether this instance is prime.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        ///   <c>true</c> if the specified i value is prime; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="System.ArgumentException">The parameter is less zero.</exception>
        public static bool IsPrime( this int iValue )
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
        /// <param name="iIterations">The count of iterations.</param>
        /// <returns></returns>
        public static UnsignedLongList GetFibonacciList( this uint iIterations )
        {
            if( iIterations == 0 )
            {
                return new();
            }

            if( iIterations == 1 )
            {
                return UnsignedLongList.From(0, 1);
            }

            //-----------------------------------------------------------------

            // If we have more than 93 iterations ulong is not big enough !
            if( iIterations > 93 )
            {
                throw new ArgumentOutOfRangeException(nameof(iIterations), "To much iterations!");
            }

            //-----------------------------------------------------------------

            ulong [] values = new ulong [iIterations + 1];

            values [0] = 0;
            values [1] = 1;

            if( iIterations > 1 )
            {
                for( int iCounter = 2 ; iCounter < iIterations + 1 ; iCounter++ )
                {
                    values [iCounter] = values [iCounter - 1] + values [iCounter - 2];
                }
            }

            return new(values);
        }
    }
}
