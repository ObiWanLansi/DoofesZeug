
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Specieses.Human.Professions
{
    [Generated]
    public static class SoldierBuilder
    {
        public static Soldier New() => new();


        public static Soldier WithSince(this Soldier soldier, DoofesZeug.Models.DateAndTime.Date since)
        {
            soldier.Since = since;
            return soldier;
        }
    }
}
