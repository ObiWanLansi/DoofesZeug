using System;
using System.Collections.Generic;
using System.Globalization;

using DoofesZeug.Attributes.Documentation;
using DoofesZeug.Entities.DateAndTime;
using DoofesZeug.Entities.DateAndTime.Part.Date;
using DoofesZeug.Tools.Misc;



namespace DoofesZeug.Extensions;

/// <summary>
/// 
/// </summary>
public static class DateTimeExtension
{
    /// <summary>
    /// yyyyMMdd
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_YYYYMMDD( this DateTime dt ) => dt.ToString("yyyyMMdd");


    /// <summary>
    /// yyyyMMdd_HHmmss
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_YYYYMMDD_HHMMSS( this DateTime dt ) => dt.ToString("yyyyMMdd_HHmmss");


    /// <summary>
    /// yyyyMMddHHmmss
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_YYYYMMDDHHMMSS( this DateTime dt ) => dt.ToString("yyyyMMddHHmmss");


    /// <summary>
    /// yyyyMMdd_HHmmssfff
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_YYYYMMDD_HHMMSSFFF( this DateTime dt ) => dt.ToString("yyyyMMdd_HHmmssfff");


    /// <summary>
    /// dd.MM.yyyy, HH:mm:ss
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_DD_MM_YYYY_HH_MM_SS( this DateTime dt ) => dt.ToString("dd.MM.yyyy, HH:mm:ss");


    /// <summary>
    /// dd.MM.yyyy, HH:mm
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_DD_MM_YYYY_HH_MM( this DateTime dt ) => dt.ToString("dd.MM.yyyy, HH:mm");


    /// <summary>
    /// dd.MM.yyyy
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_DD_MM_YYYY( this DateTime dt ) => dt.ToString("dd.MM.yyyy");


    /// <summary>
    /// HH:mm:ss
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_HH_MM_SS( this DateTime dt ) => dt.ToString("HH:mm:ss");


    /// <summary>
    /// FMTs the hh mm.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string Fmt_HH_MM( this DateTime dt ) => dt.ToString("HH:mm");

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// The cal
    /// </summary>
    private static readonly GregorianCalendar CAL = new();


    /// <summary>
    /// The dayofweek
    /// </summary>
    public static readonly SortedDictionary<DayOfWeek, int> DAYOFWEEK = new()
    {
        { DayOfWeek.Monday, 0 },
        { DayOfWeek.Tuesday, 1 },
        { DayOfWeek.Wednesday, 2 },
        { DayOfWeek.Thursday, 3 },
        { DayOfWeek.Friday, 4 },
        { DayOfWeek.Saturday, 5 },
        { DayOfWeek.Sunday, 6 }
    };


    /// <summary>
    /// Days the of week natural.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int DayOfWeekNatural( this DateTime dt ) => DAYOFWEEK [dt.DayOfWeek] + 1;

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the date.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Date GetDate( this DateTime dt ) => new(dt);


    /// <summary>
    /// Gets the time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Time GetTime( this DateTime dt ) => new(dt);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// The daynames
    /// </summary>
    public static readonly SortedDictionary<DayOfWeek, string> DAYNAME = new()
    {
        { DayOfWeek.Monday, "Montag" },
        { DayOfWeek.Tuesday, "Dienstag" },
        { DayOfWeek.Wednesday, "Mittwoch" },
        { DayOfWeek.Thursday, "Donnerstag" },
        { DayOfWeek.Friday, "Freitag" },
        { DayOfWeek.Saturday, "Samstag" },
        { DayOfWeek.Sunday, "Sonntag" }
    };


    /// <summary>
    /// The logical dayname
    /// </summary>
    public static readonly SortedDictionary<int, string> LOGICAL_DAYNAME = new()
    {
        { 1, "Montag" },
        { 2, "Dienstag" },
        { 3, "Mittwoch" },
        { 4, "Donnerstag" },
        { 5, "Freitag" },
        { 6, "Samstag" },
        { 7, "Sonntag" }
    };

    /// <summary>
    /// Gets the dayname.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string GetDayname( this DateTime dt ) => DAYNAME [dt.DayOfWeek];

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// The monthname
    /// </summary>
    public static readonly SortedDictionary<int, string> MONTHNAME = new()
    {
        { 1, "Januar" },
        { 2, "Februar" },
        { 3, "März" },
        { 4, "April" },
        { 5, "Mai" },
        { 6, "Juni" },
        { 7, "Juli" },
        { 8, "August" },
        { 9, "September" },
        { 10, "Oktober" },
        { 11, "November" },
        { 12, "Dezember" }
    };


    /// <summary>
    /// Gets the monthname.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string GetMonthname( this DateTime dt ) => MONTHNAME [dt.Month];

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the day of week.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int GetDayOfWeek( this DateTime dt )
    {
        int iValue = (int) dt.DayOfWeek - 1;

        return iValue < 0 ? 6 : iValue;
    }


    /// <summary>
    /// dd.mm.yyyy
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string DateToRoman( this DateTime dt ) => $"{Tool.NumberToRoman((ushort) dt.Day)}.{Tool.NumberToRoman((ushort) dt.Month)}.{Tool.NumberToRoman((ushort) dt.Year)}";


    /// <summary>
    /// Dayses the in month.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int DaysInMonth( this DateTime dt ) => DateTime.DaysInMonth(dt.Year, dt.Month);


    /// <summary>
    /// Firsts the day in month.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    ////static public DayOfWeek FirstDayInWeek( this DateTime dt )
    public static DayOfWeek FirstDayInMonth( this DateTime dt ) => new DateTime(dt.Year, dt.Month, 1).DayOfWeek;


    /// <summary>
    /// Weeks the of first day in month.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int WeekOfFirstDayInMonth( this DateTime dt ) =>// TODO: Ist hier CalendarWeekRule.FirstDay richtig oder wie unten CalendarWeekRule.FirstFourDayWeek ???
        CAL.GetWeekOfYear(new DateTime(dt.Year, dt.Month, 1), CalendarWeekRule.FirstDay, DayOfWeek.Monday);


    /// <summary>
    /// Weeks the of date.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int WeekOfDate( this DateTime dt )
    {
        int week = CAL.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

        return week > 0 && week < 53 ? week : 1;
    }


    /// <summary>
    /// Gets the unix time.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static ulong GetUnixTime( this DateTime dt )
    {
        DateTime dtUnix = new(1970, 1, 1, 0, 0, 0, dt.Kind);

        return (ulong) ( dt - dtUnix ).TotalSeconds;
    }


    /// <summary>
    /// Gets the unix time UTC in ms.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static ulong GetUnixTimeUTCInMilliSeconds( this DateTime dt )
    {
        DateTime dtUnix = new(1970, 1, 1, 0, 0, 0, dt.Kind);

        return (ulong) ( dt.ToUniversalTime() - dtUnix ).TotalSeconds * 1000;
    }


    /// <summary>
    /// Determines whether [is leap year].
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>
    ///   <c>true</c> if [is leap year] [the specified dt]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsLeapYear( this DateTime dt ) => DateTime.IsLeapYear(dt.Year);//    return dt.Year % 4 == 0 && ( dt.Year % 100 != 0 || dt.Year % 400 == 0 );


    /// <summary>
    /// Gets the first date in week (Monday).
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static DateTime GetFirstDateInWeek( this DateTime dt ) => dt.AddDays(DAYOFWEEK [dt.DayOfWeek] * -1).Date;


    /// <summary>
    /// Gets the laste date in week.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static DateTime GetLastDateInWeek( this DateTime dt ) => dt.AddDays(6 - DAYOFWEEK [dt.DayOfWeek]).Date + new TimeSpan(23, 59, 59);


    /// <summary>
    /// Determines whether this instance is today.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>
    ///   <c>true</c> if the specified dt is today; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsToday( this DateTime dt )
    {
        DateTime dtNow = DateTime.Now;

        return dt.Year == dtNow.Year && dt.Month == dtNow.Month && dt.Day == dtNow.Day;
    }


    /// <summary>
    /// Determines whether [is in last24 hours].
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns>
    ///   <c>true</c> if [is in last24 hours] [the specified dt]; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsInLast24Hours( this DateTime dt )
    {
        // Is der DateTime innerhalb der letzten 24 Stunden ...

        DateTime dtNow = DateTime.Now;

        if( dt > dtNow )
        {
            throw new ArgumentOutOfRangeException(nameof(dt));
        }

        TimeSpan ts = dtNow - dt;

        return ts.TotalHours < 24;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the year.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Year GetYear( this DateTime dt ) => new((uint) dt.Year);


    /// <summary>
    /// Gets the month.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Month GetMonth( this DateTime dt ) => new((uint) dt.Month);


    /// <summary>
    /// Gets the day.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Day GetDay( this DateTime dt ) => new((uint) dt.Day);


    /// <summary>
    /// Gets the week.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Week GetWeek( this DateTime dt ) => new((uint) dt.WeekOfDate());

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the quarter.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static Quarter GetQuarter( this DateTime dt ) => dt.Month switch
    {
        1 or 2 or 3 => Quarter.First,
        4 or 5 or 6 => Quarter.Second,
        7 or 8 or 9 => Quarter.Third,
        _ => Quarter.Fourth,
    };


    /// <summary>
    /// Gets the quarter as string.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static string GetQuarterAsString( this DateTime dt ) => dt.Month switch
    {
        1 or 2 or 3 => "I",
        4 or 5 or 6 => "II",
        7 or 8 or 9 => "III",
        _ => "IV",
    };


    /// <summary>
    /// Gets the quarter as int.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static int GetQuarterAsInt( this DateTime dt ) => dt.Month switch
    {
        1 or 2 or 3 => 1,
        4 or 5 or 6 => 2,
        7 or 8 or 9 => 3,
        _ => 4,
    };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    // Frühling 20.03.-20.06.
    public static readonly DateTime SPRING_START = new(1974, 03, 20);

    // Sommer   21.06.-21.09.
    public static readonly DateTime SUMMER_START = new(1974, 06, 21);

    // Herbst   22.09.-20.12.
    public static readonly DateTime AUTUMN_START = new(1974, 09, 22);

    // Winter   21.12.-19.03.
    public static readonly DateTime WINTER_START = new(1974, 12, 21);


    /// <summary>
    /// Gets the season.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    [Link("https://de.wikipedia.org/wiki/Jahreszeit#Beginn_der_Jahreszeiten")]
    public static Season? GetSeason( this DateTime dt )
    {
        // Hier eine vereinfachte Variante von der Bestimmung der Jahreszeiten, ohne Berücksichtigung des Schaltjahres

        int doy = dt.DayOfYear;

        if( doy < SPRING_START.DayOfYear || doy >= WINTER_START.DayOfYear )
        {
            return Season.Winter;
        }

        if( doy >= SPRING_START.DayOfYear && doy < SUMMER_START.DayOfYear )
        {
            return Season.Spring;
        }

        if( doy >= SUMMER_START.DayOfYear && doy < AUTUMN_START.DayOfYear )
        {
            return Season.Summer;
        }

        if( doy >= AUTUMN_START.DayOfYear && doy < WINTER_START.DayOfYear )
        {
            return Season.Autumn;
        }

        return null;
    }

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Gets the yesterday.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static DateTime GetYesterday( this DateTime dt ) => dt.AddDays(-1);


    /// <summary>
    /// Gets the tomorrow.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <returns></returns>
    public static DateTime GetTomorrow( this DateTime dt ) => dt.AddDays(1);

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Formats the specified string format.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="strFormat">The string format.</param>
    /// <returns></returns>
    public static string Format( this DateTime dt, string strFormat ) => strFormat.ToLower() switch
    {
        "doy" => $"{dt.DayOfYear}",
        "dim" => $"{dt.DaysInMonth()}",
        "unix" => $"{dt.GetUnixTime()}",
        "cw" => $"{dt.WeekOfDate()}",
        "qti" => $"{dt.GetQuarterAsInt()}",
        "qts" => $"{dt.GetQuarterAsString()}",
        "rmn" => $"{dt.DateToRoman()}",
        "season" => $"{dt.GetSeason()}",
        _ => dt.ToString(strFormat),
    };

    //-------------------------------------------------------------------------------------------------------------------------------------------------------------------------


    /// <summary>
    /// Simples the equals.
    /// </summary>
    /// <param name="dt">The dt.</param>
    /// <param name="other">The other.</param>
    /// <returns></returns>
    public static bool SimpleEquals( this DateTime dt, DateTime other )
    {
        if( dt.Year != other.Year )
        {
            return false;
        }

        if( dt.Month != other.Month )
        {
            return false;
        }

        if( dt.Day != other.Day )
        {
            return false;
        }

        if( dt.Hour != other.Hour )
        {
            return false;
        }

        if( dt.Minute != other.Minute )
        {
            return false;
        }

        if( dt.Second != other.Second )
        {
            return false;
        }

        return dt.Kind == other.Kind;
    }
}
