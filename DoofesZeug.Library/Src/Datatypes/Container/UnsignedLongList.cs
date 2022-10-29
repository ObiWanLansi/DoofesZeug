using System.Collections.Generic;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class UnsignedLongList : List<ulong>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedLongList"/> class.
        /// </summary>
        public UnsignedLongList()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedLongList"/> class.
        /// </summary>
        /// <param name="iSize">Size of the i.</param>
        public UnsignedLongList(int iSize) :
            base(iSize)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedLongList"/> class.
        /// </summary>
        /// <param name="iArray">The i array.</param>
        public UnsignedLongList(ulong[] iArray)
            : base(iArray)
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="UnsignedLongList"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public UnsignedLongList(IEnumerable<ulong> collection) :
            base(collection)
        {
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static UnsignedLongList From(params ulong[] values) => new(values);
    }
}
