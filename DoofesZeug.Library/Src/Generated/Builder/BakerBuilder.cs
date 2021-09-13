
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class BakerBuilder
    {
        public static Baker New() => new();


        public static Baker WithSince(this Baker baker, DoofesZeug.Entities.DateAndTime.Date since)
        {
            baker.Since = since;
            return baker;
        }
    }
}
