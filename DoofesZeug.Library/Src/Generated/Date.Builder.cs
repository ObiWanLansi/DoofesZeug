namespace DoofesZeug.Models.DateAndTime
{
    public static class DateBuilder
    {
        public static Date New() => new();


        public static Date Day(this Date date, System.Int32 day)
        {
            date.Day = day;
            return date;
        }


        public static Date Month(this Date date, System.Int32 month)
        {
            date.Month = month;
            return date;
        }


        public static Date Year(this Date date, System.Int32 year)
        {
            date.Year = year;
            return date;
        }
    }
}
