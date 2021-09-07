using System.Collections.Generic;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class IntegerList : List<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerList"/> class.
        /// </summary>
        public IntegerList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerList"/> class.
        /// </summary>
        /// <param name="iSize">Size of the i.</param>
        public IntegerList( int iSize ) :
            base(iSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerList"/> class.
        /// </summary>
        /// <param name="iArray">The i array.</param>
        public IntegerList( int [] iArray )
            : base(iArray)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntegerList"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public IntegerList( IEnumerable<int> collection ) :
            base(collection)
        {
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="ilSource">The il source.</param>
        /// <param name="iMultiplier">The i multiplier.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static IntegerList operator *( IntegerList ilSource, int iMultiplier )
        {
            IntegerList ilDestination = new(ilSource);

            for( int i = 0 ; i < ilDestination.Count ; i++ )
            {
                ilDestination [i] *= iMultiplier;
            }

            return ilDestination;
        }
    }
}
