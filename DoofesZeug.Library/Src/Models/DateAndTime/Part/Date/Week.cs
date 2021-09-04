﻿using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Description("The week of an date in the year.")]
    [Range(1, 53)]
    public sealed class Week : DateTimePart
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Week"/> class.
        /// </summary>
        public Week()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Week"/> class.
        /// </summary>
        /// <param name="iInitalValue">The i inital value.</param>
        public Week( uint iInitalValue ) : base(iInitalValue)
        {
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="System.UInt32"/> to <see cref="Week"/>.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Week( uint iValue ) => new(iValue);


        /// <summary>
        /// Performs an implicit conversion from <see cref="Week"/> to <see cref="System.UInt32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator uint( Week value ) => value.Value;
    }
}
