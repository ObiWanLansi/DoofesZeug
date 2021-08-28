using System;



namespace DoofesZeug.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class RangeAttribute : Attribute
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public RangeAttribute( int min, int max )
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
