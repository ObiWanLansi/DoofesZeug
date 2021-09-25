using System;

using DoofesZeug.Datatypes.Container;



namespace DoofesZeug.Attributes.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class LengthAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines the minimum of the string.
        /// </summary>
        /// <value>
        /// The minimum.
        /// </value>
        public uint Min { get; private set; }

        /// <summary>
        /// Determines the maximum of the string.
        /// </summary>
        /// <value>
        /// The maximum.
        /// </value>
        public uint Max { get; private set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RangeAttribute"/> class.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        public LengthAttribute( uint min, uint max )
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
                uint length = (uint) ( value as string ).Length;

                if( length < this.Min )
                {
                    return new StringList { $"The current length '{ length }' is less than the minimum length '{ this.Min }'!" };
                }

                if( length > this.Max )
                {
                    return new StringList { $"The current length '{ length }' is greater than the maximum length '{ this.Max }'!" };
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
