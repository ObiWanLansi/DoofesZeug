using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums;

[Description("An simple enumeration for methos or parameters which line ending should be used.")]
public enum LineEnding : byte
{
    /// <summary>
    /// The windows LineEnding (\r\n).
    /// </summary>
    Windows,

    /// <summary>
    /// The linux & unix  LineEnding (\n).
    /// </summary>
    LinuxUnix
}
