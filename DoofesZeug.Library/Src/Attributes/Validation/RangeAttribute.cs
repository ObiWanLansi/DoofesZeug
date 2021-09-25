﻿using System;

using DoofesZeug.Datatypes.Container;



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
        public double Min { get; private set; }

        /// <summary>
        /// Determines the maximum of the parameters.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public double Max { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public RangeAttribute( double min, double max )
        {
            this.Min = min;
            this.Max = max;
        }


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
