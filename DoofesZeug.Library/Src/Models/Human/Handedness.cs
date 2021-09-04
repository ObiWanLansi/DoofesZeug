using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Human
{
    [Description("An simple enumeration for the handedness of an human.")]
    public enum Handedness : byte
    {
        Unknown,
        Left,
        Right,
        Both
    }
}
