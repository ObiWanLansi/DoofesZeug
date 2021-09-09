
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Specieses.Human.Professions
{
    [Generated]
    public static class DoctorBuilder
    {
        public static Doctor New() => new();


        public static Doctor WithSince(this Doctor doctor, DoofesZeug.Models.DateAndTime.Date since)
        {
            doctor.Since = since;
            return doctor;
        }
    }
}
