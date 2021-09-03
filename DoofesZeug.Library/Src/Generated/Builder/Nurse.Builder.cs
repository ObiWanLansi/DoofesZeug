
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Human.Professions
{
    [Generated]
    public static class NurseBuilder
    {
        public static Nurse New() => new();


        public static Nurse WithSince(this Nurse nurse, DoofesZeug.Models.DateAndTime.Date since)
        {
            nurse.Since = since;
            return nurse;
        }


        public static Nurse WithId(this Nurse nurse, System.Guid id)
        {
            nurse.Id = id;
            return nurse;
        }
    }
}
