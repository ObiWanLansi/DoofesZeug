using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools
{
    [Description("An generic TextAlign for console output, or maybe to use in markdown/html generators.")]
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
}
