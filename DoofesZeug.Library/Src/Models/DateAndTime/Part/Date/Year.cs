﻿using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Range(0, 2500)]
    public sealed class Year : DateTimePart
    {
        public Year()
        {
        }


        public Year( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Year( int iValue ) => new(iValue);

        public static implicit operator int( Year value ) => value.Value;
    }
}
