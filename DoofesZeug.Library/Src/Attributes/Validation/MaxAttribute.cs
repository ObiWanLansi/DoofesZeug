using System;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MaxAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public int Max { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MaxAttribute"/> class.
        /// </summary>
        /// <param name="max">The maximum.</param>
        public MaxAttribute( int max ) => this.Max = max;
    }
}
