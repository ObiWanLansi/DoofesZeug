using System.Collections.Generic;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class DataTreeItems : List<DataTree>
    {
    }



    public sealed class DataTree
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; init; }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public DataTreeItems Items { get; init; }
    }
}
