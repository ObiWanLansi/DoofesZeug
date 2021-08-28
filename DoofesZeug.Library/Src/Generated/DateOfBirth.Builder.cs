
// --------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation!
// --------------------------------------------------------------------------------------------------------------------
        


namespace DoofesZeug.Models.Human
{
    public static class DateOfBirthBuilder
    {
        public static DateOfBirth New() => new();


        public static DateOfBirth Day(this DateOfBirth dateofbirth, DoofesZeug.Models.DateAndTime.Part.Date.Day day)
        {
            dateofbirth.Day = day;
            return dateofbirth;
        }


        public static DateOfBirth Month(this DateOfBirth dateofbirth, DoofesZeug.Models.DateAndTime.Part.Date.Month month)
        {
            dateofbirth.Month = month;
            return dateofbirth;
        }


        public static DateOfBirth Year(this DateOfBirth dateofbirth, DoofesZeug.Models.DateAndTime.Part.Date.Year year)
        {
            dateofbirth.Year = year;
            return dateofbirth;
        }
    }
}
