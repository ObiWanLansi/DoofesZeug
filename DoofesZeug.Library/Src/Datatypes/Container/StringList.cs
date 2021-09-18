using System.Collections.Generic;
using System.Linq;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class StringList : List<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        public StringList()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        /// <param name="iSize">Size of the i.</param>
        public StringList( int iSize )
            : base(iSize)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        /// <param name="strArray">The string array.</param>
        public StringList( string [] strArray )
            : base(strArray)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        /// <param name="collection">Die Auflistung, deren Elemente in die neue Liste kopiert werden.</param>
        public StringList( IEnumerable<string> collection )
            : base(collection)
        {
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Performs an implicit conversion from <see cref="StringList"/> to <see cref="string[]"/>.
        /// </summary>
        /// <param name="sl">The sl.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator string []( StringList sl ) => sl.ToArray();

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the enumerable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static StringList From<T>( IEnumerable<T> list ) => new(list.Select(item => item?.ToString()));


        /// <summary>
        /// Froms the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        static public StringList From( params string [] values ) => new (values);
    }
}
