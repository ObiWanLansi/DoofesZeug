using System;

using DoofesZeug.Datatypes.Container;



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
        public double Min { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="MinAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        public MinAttribute( double min ) => this.Min = min;


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

                if( d < this.Min )
                {
                    return new StringList { $"The current value '{ d }' is less than the minimum value '{ this.Min }'!" };
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
