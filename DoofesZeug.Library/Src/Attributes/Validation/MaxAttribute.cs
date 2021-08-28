using System;



namespace DoofesZeug.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MaxAttribute : ValidationAttribute
    {
        public int Max { get; private set; }

        public MaxAttribute( int max ) => this.Max = max;
    }
}
