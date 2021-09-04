using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Tools.Crypt
{
    [Description("All supported HashAlgorithm for the SimpleHash class.")]
    public enum SupportedHashAlgorithm : byte
    {
        MD5,

        SHA1,

        SHA256,

        SHA512

    }
}
