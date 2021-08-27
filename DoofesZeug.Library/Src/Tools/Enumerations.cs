


namespace DoofesZeug.Tools
{
    public enum VerbosityLevel : byte
    {
        /// <summary>
        /// Gar keine Ausgabe.
        /// </summary>
        None,

        /// <summary>
        /// Wenig Ausgabe.
        /// </summary>
        Low,

        /// <summary>
        /// Normale Ausgabe.
        /// </summary>
        Normal,

        /// <summary>
        /// Hohe Ausgabe.
        /// </summary>
        High
    }


    public enum Priority : byte
    {
        /// <summary>
        /// Niedrige Priorität.
        /// </summary>
        Low,

        /// <summary>
        /// Normale Priorität.
        /// </summary>
        Normal,

        /// <summary>
        /// Hohe Priorität.
        /// </summary>
        High
    }


    public enum TextAlign : byte
    {
        /// <summary>
        /// The left
        /// </summary>
        Left,

        /// <summary>
        /// The center
        /// </summary>
        Center,

        /// <summary>
        /// The right
        /// </summary>
        Right
    }


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


    public enum LineEnding : byte
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
