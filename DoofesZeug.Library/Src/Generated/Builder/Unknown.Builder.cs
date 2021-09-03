
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class UnknownBuilder
    {
        public static Unknown New() => new();


        public static Unknown WithSince(this Unknown unknown, DoofesZeug.Models.DateAndTime.Date since)
        {
            unknown.Since = since;
            return unknown;
        }


        public static Unknown WithId(this Unknown unknown, System.Guid id)
        {
            unknown.Id = id;
            return unknown;
        }
    }
}
