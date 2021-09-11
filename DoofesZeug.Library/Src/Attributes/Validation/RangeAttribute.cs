using System;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class RangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public int Min { get; private set; }

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public int Max { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public RangeAttribute( int min, int max )
        {
            this.Min = min;
            this.Max = max;
        }
    }
}
