using System;
using System.Collections.Generic;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class StringSet : SortedSet<string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringSet"/> class.
        /// </summary>
        public StringSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        /// <param name="strArray">The string array.</param>
        public StringSet(string[] strArray)
            : base(strArray)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringList"/> class.
        /// </summary>
        /// <param name="collection">Die Auflistung, deren Elemente in die neue Liste kopiert werden.</param>
        public StringSet(IEnumerable<string> collection)
            : base(collection)
        {
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Froms the specified values.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns></returns>
        public static StringSet From(params string[] values) => new(values);

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Gets the <see cref="string"/> with the specified i index.
        /// </summary>
        /// <value>
        /// The <see cref="string"/>.
        /// </value>
        /// <param name="iIndex">Index of the i.</param>
        /// <returns></returns>
        public string this[int iIndex]
        {
            get
            {
                int iCounter = 0;

                foreach (string strValue in this)
                {
                    if (iCounter == iIndex)
                    {
                        return strValue;
                    }

                    iCounter++;
                }

                throw new IndexOutOfRangeException();
            }
        }
    }
}
