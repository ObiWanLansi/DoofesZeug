
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class CarpenterBuilder
    {
        public static Carpenter New() => new();


        public static Carpenter WithSince(this Carpenter carpenter, DoofesZeug.Models.DateAndTime.Date since)
        {
            carpenter.Since = since;
            return carpenter;
        }


        public static Carpenter WithId(this Carpenter carpenter, System.Guid id)
        {
            carpenter.Id = id;
            return carpenter;
        }
    }
}
