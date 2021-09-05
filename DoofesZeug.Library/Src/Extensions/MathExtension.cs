using System;



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
        /// <exception cref="ArgumentException"></exception>
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
    }
}
