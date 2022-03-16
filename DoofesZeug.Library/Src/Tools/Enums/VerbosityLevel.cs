using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Enums
{
    [Description("An generic verbosity level for logging output.")]
    public enum VerbosityLevel : byte
    {
        None,
        Low,
        Normal,
        High
    }
}
