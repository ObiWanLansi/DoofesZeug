using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.Specieses
{
    [Description("An enumeration for the gender of creatures.")]
    public enum Gender : byte
    {
        // When we not know, what for an gender an human have, the property should be null.
        // Unknown,

        Divers,
        Female,
        Male
    }
}
