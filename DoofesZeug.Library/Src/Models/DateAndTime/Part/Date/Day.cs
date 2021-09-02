﻿using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Range(1, 31)]
    public sealed class Day : DateTimePart
    {
        public Day()
        {
        }

        public Day( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Day( int iValue ) => new(iValue);

        public static implicit operator int( Day value ) => value.Value;
    }
}
