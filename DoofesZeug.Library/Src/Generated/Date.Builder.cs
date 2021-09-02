
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Models.Datatypes.DateAndTime
{
    [Generated]
    public static class DateBuilder
    {
        public static Date New() => new();


        public static Date WithDay(this Date date, DoofesZeug.Models.Datatypes.DateAndTime.Part.Date.Day day)
        {
            date.Day = day;
            return date;
        }


        public static Date WithMonth(this Date date, DoofesZeug.Models.Datatypes.DateAndTime.Part.Date.Month month)
        {
            date.Month = month;
            return date;
        }


        public static Date WithYear(this Date date, DoofesZeug.Models.Datatypes.DateAndTime.Part.Date.Year year)
        {
            date.Year = year;
            return date;
        }
    }
}
