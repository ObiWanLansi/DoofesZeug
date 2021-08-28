using System;



namespace DoofesZeug.Models
{
    public abstract class IdentifiableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
