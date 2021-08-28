using System;



namespace DoofesZeug.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MinAttribute : ValidationAttribute
    {
        public int Min { get; private set; }

        public MinAttribute( int min ) => this.Min = min;
    }
}
