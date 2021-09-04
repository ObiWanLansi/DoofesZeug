using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools
{
    [Description("")]
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
}
