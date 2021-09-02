﻿using DoofesZeug.Attributes.Validation;



namespace DoofesZeug.Models.DateAndTime.Part.Date
{
    [Range(1, 12)]
    public sealed class Month : DateTimePart
    {
        public Month() { 
        }


        public Month( int iInitalValue ) : base(iInitalValue)
        {
        }


        public static implicit operator Month( int iValue ) => new(iValue);

        public static implicit operator int( Month value ) => value.Value;
    }
}
