
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class FireFighterBuilder
    {
        public static FireFighter New() => new();


        public static FireFighter WithSince(this FireFighter firefighter, DoofesZeug.Models.DateAndTime.Date since)
        {
            firefighter.Since = since;
            return firefighter;
        }


        public static FireFighter WithId(this FireFighter firefighter, System.Guid id)
        {
            firefighter.Id = id;
            return firefighter;
        }
    }
}
