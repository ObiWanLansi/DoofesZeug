using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums
{
    [Description("An generic VerbosityLevel for logging output.")]
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
