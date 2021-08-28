using System;



namespace DoofesZeug.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MinAttribute : Attribute
    {
        public int Min { get; private set; }

        public MinAttribute( int min ) => this.Min = min;
    }
}
