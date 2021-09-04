using System;

using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models
{
    [Description("An baseclass for all other entities who should have an unique id as Guid.")]
    public abstract class IdentifiableEntity : EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
