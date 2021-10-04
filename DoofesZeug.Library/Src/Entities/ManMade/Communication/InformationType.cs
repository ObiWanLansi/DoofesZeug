using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Entities.ManMade.Communication
{
    [Description("An little type if the information (email, phone) is private or an business information.")]
    public enum InformationType : byte
    {
        Private,

        Business
    }
}
