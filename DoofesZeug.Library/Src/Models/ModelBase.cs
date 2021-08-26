using System;

namespace DoofesZeug.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
