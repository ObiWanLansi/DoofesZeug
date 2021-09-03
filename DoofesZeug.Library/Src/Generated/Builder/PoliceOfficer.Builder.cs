
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class PoliceOfficerBuilder
    {
        public static PoliceOfficer New() => new();


        public static PoliceOfficer WithSince(this PoliceOfficer policeofficer, DoofesZeug.Models.DateAndTime.Date since)
        {
            policeofficer.Since = since;
            return policeofficer;
        }


        public static PoliceOfficer WithId(this PoliceOfficer policeofficer, System.Guid id)
        {
            policeofficer.Id = id;
            return policeofficer;
        }
    }
}
