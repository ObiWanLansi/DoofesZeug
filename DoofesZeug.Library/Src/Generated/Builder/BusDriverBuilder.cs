﻿
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class BusDriverBuilder
    {
        public static BusDriver New() => new();


        public static BusDriver WithSince(this BusDriver busdriver, DoofesZeug.Entities.DateAndTime.Date since)
        {
            busdriver.Since = since;
            return busdriver;
        }
    }
}
