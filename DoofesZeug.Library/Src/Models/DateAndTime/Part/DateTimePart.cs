﻿using DoofesZeug.Attributes.Documentation;



namespace DoofesZeug.Models.DateAndTime.Part
{
    [Description("An abstract base class for all other parts of an date or an time.")]
    public abstract class DateTimePart : EntityBase
    {
        public uint Value { get; set; }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePart"/> class.
        /// </summary>
        protected DateTimePart()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimePart"/> class.
        /// </summary>
        /// <param name="iValue">The i value.</param>
        protected DateTimePart( uint iValue ) => this.Value = iValue;

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{this.Value}";


        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals( object obj )
        {
            if( obj == null )
            {
                return false;
            }

            if( obj is not DateTimePart other )
            {
                return false;
            }

            if( this.Value != other.Value )
            {
                return false;
            }

            return true;
        }
    }
}
