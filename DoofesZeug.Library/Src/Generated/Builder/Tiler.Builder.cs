﻿
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class TilerBuilder
    {
        public static Tiler New() => new();


        public static Tiler WithSince(this Tiler tiler, DoofesZeug.Models.DateAndTime.Date since)
        {
            tiler.Since = since;
            return tiler;
        }


        public static Tiler WithId(this Tiler tiler, System.Guid id)
        {
            tiler.Id = id;
            return tiler;
        }
    }
}
