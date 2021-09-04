using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools
{
    [Description("An generic SortOrder to use in some mehtods for lists or datatables.")]
    public enum SortOrder : byte
    {
        /// <summary>
        /// Ascending
        /// </summary>
        Ascending,

        /// <summary>
        /// Descending
        /// </summary>
        Descending
    }
}
