using System;



namespace DoofesZeug.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MaxAttribute : Attribute
    {
        public int Max { get; private set; }

        public MaxAttribute( int max ) => this.Max = max;
    }
}
