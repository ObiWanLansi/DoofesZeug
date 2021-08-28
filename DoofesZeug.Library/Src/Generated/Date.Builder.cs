
// --------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation!
// --------------------------------------------------------------------------------------------------------------------
        


namespace DoofesZeug.Models.DateAndTime
{
    public static class DateBuilder
    {
        public static Date New() => new();


        public static Date Day(this Date date, DoofesZeug.Models.DateAndTime.Part.Date.Day day)
        {
            date.Day = day;
            return date;
        }


        public static Date Month(this Date date, DoofesZeug.Models.DateAndTime.Part.Date.Month month)
        {
            date.Month = month;
            return date;
        }


        public static Date Year(this Date date, DoofesZeug.Models.DateAndTime.Part.Date.Year year)
        {
            date.Year = year;
            return date;
        }
    }
}
