using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums
{
    [Description("An generic text align for console output, or maybe to use in markdown/html generators.")]
    public enum TextAlign : byte
    {
        /// <summary>
        /// Left alignment.
        /// </summary>
        Left,

        /// <summary>
        /// Center alignment.
        /// </summary>
        Center,

        /// <summary>
        /// Right alignment.
        /// </summary>
        Right
    }
}
