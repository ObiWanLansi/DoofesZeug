using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums
{
    [Description("The PathStyle for filenames (\\\\ or /).")]
    public enum PathStyle : byte
    {
        /// <summary>
        /// The windows path style.
        /// </summary>
        Windows,

        /// <summary>
        /// The linux path style.
        /// </summary>
        Linux
    }
}
