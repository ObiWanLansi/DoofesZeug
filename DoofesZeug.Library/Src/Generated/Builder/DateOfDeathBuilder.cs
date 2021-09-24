
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.DateAndTime
{
    [Generated]
    public static class DateOfDeathBuilder
    {
        public static DateOfDeath New() => new();


        public static DateOfDeath WithDay(this DateOfDeath dateofdeath, DoofesZeug.Entities.DateAndTime.Part.Date.Day day)
        {
            dateofdeath.Day = day;
            return dateofdeath;
        }


        public static DateOfDeath WithMonth(this DateOfDeath dateofdeath, DoofesZeug.Entities.DateAndTime.Part.Date.Month month)
        {
            dateofdeath.Month = month;
            return dateofdeath;
        }


        public static DateOfDeath WithYear(this DateOfDeath dateofdeath, DoofesZeug.Entities.DateAndTime.Part.Date.Year year)
        {
            dateofdeath.Year = year;
            return dateofdeath;
        }
    }
}
