using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An enumeration for our seasons.")]
    public enum Season : byte
    {
        Unknown,

        Winter,
        Spring,
        Summer,
        Autumn
    }
}
