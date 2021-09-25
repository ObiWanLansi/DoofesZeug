using System;

using DoofesZeug.Datatypes.Container;



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
        public double Max { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MaxAttribute"/> class.
        /// </summary>
        /// <param name="max">The maximum.</param>
        public MaxAttribute( double max ) => this.Max = max;


        /// <summary>
        /// Validates the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public override StringList Validate( object value )
        {
            try
            {
                double d = Convert.ToDouble(value);

                if( d > this.Max )
                {
                    return new StringList { $"The current value '{ d }' is greater than the maximum value '{ this.Max }'!" };
                }
            }
            catch( Exception ex )
            {
                return new StringList { ex.Message };
            }

            return null;
        }
    }
}
