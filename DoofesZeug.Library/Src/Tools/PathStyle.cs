using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools
{
    [Description("The PathStyle for filenames (\\\\ or /).")]
    public enum PathStyle : byte
    {
        /// <summary>
        /// The windows
        /// </summary>
        Windows,

        /// <summary>
        /// The linux unix
        /// </summary>
        LinuxUnix
    }
}
