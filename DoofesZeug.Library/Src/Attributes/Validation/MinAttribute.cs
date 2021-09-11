using System;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class MinAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines the minimum of the parameters.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public int Min { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MinAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        public MinAttribute( int min ) => this.Min = min;
    }
}
