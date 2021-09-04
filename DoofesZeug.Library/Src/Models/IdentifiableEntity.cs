using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models
{
    [Description("")]
    public abstract class IdentifiableEntity : EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
