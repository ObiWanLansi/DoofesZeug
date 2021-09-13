
// ------------------------------------------------------------------------------------------------------------------
// This is auto generated code. Every manually change in this code will be overwritten at the next code generation! |
// ------------------------------------------------------------------------------------------------------------------
        
using DoofesZeug.Attributes;



namespace DoofesZeug.Entities.DateAndTime
{
    [Generated]
    public static class TimeBuilder
    {
        public static Time New() => new();


        public static Time WithHour(this Time time, DoofesZeug.Entities.DateAndTime.Part.Time.Hour hour)
        {
            time.Hour = hour;
            return time;
        }


        public static Time WithMinute(this Time time, DoofesZeug.Entities.DateAndTime.Part.Time.Minute minute)
        {
            time.Minute = minute;
            return time;
        }


        public static Time WithSecond(this Time time, DoofesZeug.Entities.DateAndTime.Part.Time.Second second)
        {
            time.Second = second;
            return time;
        }
    }
}
