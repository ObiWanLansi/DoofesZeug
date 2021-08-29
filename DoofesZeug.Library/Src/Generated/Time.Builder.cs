
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        


namespace DoofesZeug.Models.DateAndTime
{
    public static class TimeBuilder
    {
        public static Time New() => new();


        public static Time Hour(this Time time, DoofesZeug.Models.DateAndTime.Part.Time.Hour hour)
        {
            time.Hour = hour;
            return time;
        }


        public static Time Minute(this Time time, DoofesZeug.Models.DateAndTime.Part.Time.Minute minute)
        {
            time.Minute = minute;
            return time;
        }


        public static Time Second(this Time time, DoofesZeug.Models.DateAndTime.Part.Time.Second second)
        {
            time.Second = second;
            return time;
        }
    }
}
