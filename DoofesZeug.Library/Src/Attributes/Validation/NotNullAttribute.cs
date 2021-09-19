using System;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class NotNullAttribute : ValidationAttribute
    {
    }
}
