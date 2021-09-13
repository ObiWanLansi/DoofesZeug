using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.Specieses.Human
{
    [Description("The five big major religions.")]
    [Link("https://en.wikipedia.org/wiki/Major_religious_groups")]
    public enum MajorReligion : byte
    {
        Hinduism,
        Buddhism,
        Islam,
        Christianity,
        Judaism
    }
}
