using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime
{
    [Description("An enumeration for our calendar quarters.")]
    public enum Quarter : byte
    {
        Unknown = 0,

        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }
}
