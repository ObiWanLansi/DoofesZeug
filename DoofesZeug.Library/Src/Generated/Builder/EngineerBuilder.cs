
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class EngineerBuilder
    {
        public static Engineer New() => new();


        public static Engineer WithSince(this Engineer engineer, DoofesZeug.Entities.DateAndTime.Date since)
        {
            engineer.Since = since;
            return engineer;
        }
    }
}
