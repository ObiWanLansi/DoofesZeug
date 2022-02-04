using System.Collections.Generic;



namespace DoofesZeug.Datatypes.Container
{
    public sealed class DataTreeItems : List<DataTree>
    {
    }



    public sealed class DataTree
    {
        public object Data { get; init; }

        public DataTreeItems Items { get; init; }
    }
}
