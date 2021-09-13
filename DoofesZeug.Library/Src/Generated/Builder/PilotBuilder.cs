
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class PilotBuilder
    {
        public static Pilot New() => new();


        public static Pilot WithSince(this Pilot pilot, DoofesZeug.Entities.DateAndTime.Date since)
        {
            pilot.Since = since;
            return pilot;
        }
    }
}
