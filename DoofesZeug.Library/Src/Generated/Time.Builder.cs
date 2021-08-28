namespace DoofesZeug.Models.DateAndTime
{
    public static class TimeBuilder
    {
        public static Time New() => new();


        public static Time Hour(this Time time, System.Int32 hour)
        {
            time.Hour = hour;
            return time;
        }


        public static Time Minute(this Time time, System.Int32 minute)
        {
            time.Minute = minute;
            return time;
        }


        public static Time Second(this Time time, System.Int32 second)
        {
            time.Second = second;
            return time;
        }
    }
}
