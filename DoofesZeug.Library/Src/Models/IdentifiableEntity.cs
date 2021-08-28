using System;



namespace DoofesZeug.Models
{
    public abstract class IdentifiableEntity : EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
