
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.DateAndTime
{
    [Generated]
    public static class DateOfBirthBuilder
    {
        public static DateOfBirth New() => new();


        public static DateOfBirth WithDay(this DateOfBirth dateofbirth, DoofesZeug.Entities.DateAndTime.Part.Date.Day day)
        {
            dateofbirth.Day = day;
            return dateofbirth;
        }


        public static DateOfBirth WithMonth(this DateOfBirth dateofbirth, DoofesZeug.Entities.DateAndTime.Part.Date.Month month)
        {
            dateofbirth.Month = month;
            return dateofbirth;
        }


        public static DateOfBirth WithYear(this DateOfBirth dateofbirth, DoofesZeug.Entities.DateAndTime.Part.Date.Year year)
        {
            dateofbirth.Year = year;
            return dateofbirth;
        }
    }
}
