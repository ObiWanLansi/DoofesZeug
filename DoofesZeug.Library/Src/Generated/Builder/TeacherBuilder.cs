
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.Specieses.Human.Professions
{
    [Generated]
    public static class TeacherBuilder
    {
        public static Teacher New() => new();


        public static Teacher WithSince(this Teacher teacher, DoofesZeug.Entities.DateAndTime.Date since)
        {
            teacher.Since = since;
            return teacher;
        }
    }
}
