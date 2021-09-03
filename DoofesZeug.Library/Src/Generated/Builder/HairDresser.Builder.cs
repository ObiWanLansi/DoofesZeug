
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class HairDresserBuilder
    {
        public static HairDresser New() => new();


        public static HairDresser WithSince(this HairDresser hairdresser, DoofesZeug.Models.DateAndTime.Date since)
        {
            hairdresser.Since = since;
            return hairdresser;
        }


        public static HairDresser WithId(this HairDresser hairdresser, System.Guid id)
        {
            hairdresser.Id = id;
            return hairdresser;
        }
    }
}
