using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

public class UtilitiesDate
{
    public static string GetTimeUpdate(DateTime dt)
    {
        DateTime dtNow = DateTime.Now;
        if (dt.Date != dtNow.Date)
            dtNow = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

        TimeSpan ts = (dtNow - dt);
        bool isDayOfThisWeek = false;
        bool isDayOfAfterWeek = false;
        int dayNow = GetIntDayOfWeek(dtNow);
        int dayProcess = GetIntDayOfWeek(dt);
        int dayPart = dtNow.Day - dt.Day;

        double totalDayProcess = ts.TotalDays;
        double totalHoursUpdate = ts.TotalHours;
        double totalMinutesUpdate = ts.TotalMinutes;
        double totalSecondsUpdate = ts.TotalSeconds;

        if (dt.Month == dtNow.Month && dt.Year == dtNow.Year)
        {
            // Ngày chủ nhật thì khoảng ngày <=7
            if (dayNow == 1 && dayPart <= 7)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 7 && dayPart < 7)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 6 && dayPart < 6)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 5 && dayPart < 5)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 4 && dayPart < 4)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 3 && dayPart < 3)
            {
                isDayOfThisWeek = true;
            }
            else if (dayNow == 2 && dayPart < 2)
            {
                isDayOfThisWeek = true;
            }
        }

        if (dt.Month == dtNow.Month && dt.Year == dtNow.Year)
        {
            // Ngày chủ nhật thì khoảng ngày <=7
            if (dayNow == 1 && dayPart > 7 && dayPart <= 14)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 7 && dayPart >= 7 && dayPart <= 14)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 6 && dayPart >= 6 && dayPart <= 13)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 5 && dayPart >= 5 && dayPart <= 12)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 4 && dayPart >= 4 && dayPart <= 11)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 3 && dayPart >= 3 && dayPart <= 10)
            {
                isDayOfAfterWeek = true;
            }
            else if (dayNow == 2 && dayPart >= 2 && dayPart <= 9)
            {
                isDayOfAfterWeek = true;
            }
        }

        int hourUpdate = ts.Hours;
        //Vừa xong : <10s
        if (totalSecondsUpdate < 10)
            return "Vừa xong";
        //x giây trước: <60s
        if (totalSecondsUpdate < 60)
            return (int)totalSecondsUpdate + " giây trước";
        //x phút trước : <60p
        if (totalHoursUpdate < 1)
            return (int)totalMinutesUpdate + " phút trước";
        //x giờ trước : <24h      
        if (totalHoursUpdate < 24)
            return (int)totalHoursUpdate + " giờ trước";
        //Hôm qua : <48h
        if (totalHoursUpdate < 48)
            return "Hôm qua";
        //Hôm kia : <72h
        if (totalHoursUpdate < 72)
            return "Hôm kia";
        //Thứ x hoặc Chủ nhật hoặc Thứ x tuần trước <14 ngày
        // Nếu là các ngày trong tuần thì Thứ x hoặc chủ nhật
        if (dayProcess < 14)
        {
            if (isDayOfThisWeek)
            {
                return GetStringDayOfWeek(dt);
            }

            if (isDayOfAfterWeek)
            {
                return GetStringDayOfWeek(dt, " tuần trước");
            }
        }

        //x tuần trước : < 30 ngày
        if (totalDayProcess < 30)
        {
            double tuan = Math.Round(totalDayProcess / 7);
            if (tuan == 4)
            {
                return "1 tháng trước";
            }
            else
            {
                return Math.Round(totalDayProcess / 7) + " tuần trước";
            }
        }

        //x tháng trước : <12 tháng
        if (totalDayProcess < 365)
            return Math.Round(totalDayProcess / 30) + " tháng trước";
        //else : dd/mm/yyyy hh:mm
        return UtilityFormat.FormatDateTimeToStringFullMinute(dt);
    }

    public static int GetTotalDays(DateTime dt1, DateTime dt2)
    {
        try { return (dt2.Date - dt1.Date).Days; }
        catch { return 0; }
    }

    public static string GetStringDayOfWeek(DateTime dt)
    {
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return "Thứ 2";
            case DayOfWeek.Tuesday:
                return "Thứ 3";
            case DayOfWeek.Wednesday:
                return "Thứ 4";
            case DayOfWeek.Thursday:
                return "Thứ 5";
            case DayOfWeek.Friday:
                return "Thứ 6";
            case DayOfWeek.Saturday:
                return "Thứ 7";
            default: return "Chủ nhật";
        }
    }

    public static string GetStringDayOfWeek(DateTime dt, string after)
    {
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return "Thứ 2" + after;
            case DayOfWeek.Tuesday:
                return "Thứ 3" + after;
            case DayOfWeek.Wednesday:
                return "Thứ 4" + after;
            case DayOfWeek.Thursday:
                return "Thứ 5" + after;
            case DayOfWeek.Friday:
                return "Thứ 6" + after;
            case DayOfWeek.Saturday:
                return "Thứ 7" + after;
            default: return "Chủ nhật" + after;
        }
    }

    public static int GetIntDayOfWeek(DateTime dt)
    {
        switch (dt.DayOfWeek)
        {
            case DayOfWeek.Monday:
                return 2;
            case DayOfWeek.Tuesday:
                return 3;
            case DayOfWeek.Wednesday:
                return 4;
            case DayOfWeek.Thursday:
                return 5;
            case DayOfWeek.Friday:
                return 6;
            case DayOfWeek.Saturday:
                return 7;
            default: return 1;
        }
    }

    public static int GetWeekOfYear(DateTime dt)
    {
        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
        Calendar cal = dfi.Calendar;
        return cal.GetWeekOfYear(dt, dfi.CalendarWeekRule, DayOfWeek.Monday) - 1;
    }

    public static int GetWeekOfMonth(DateTime dt)
    {
        DateTime dtFirstInMonth = new DateTime(dt.Year, dt.Month, 1);
        return GetWeekOfYear(dt) - GetWeekOfYear(dtFirstInMonth) + 1;
    }

    public static bool CompareTimeBetween(DateTime datetime1, DateTime datetime2, DateTime datetime)
    {
        int result1 = DateTime.Compare(datetime1, datetime);
        int result2 = DateTime.Compare(datetime2, datetime);
        return result1 < 0 && result2 > 0;
    }

    ///<authors>
    ///CuongVMb-20150625-T?o m?i
    ///</authors>
    /// <summary>
    /// <para>L?y ngày cu?i cùng c?a tháng truy?n vào</para>
    /// </summary>
    /// <param name="iMonth"></param>
    /// <returns></returns>
    public static DateTime GetLastDayOfMonth()
    {
        try
        {
            DateTime dtResult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            return dtResult;
        }
        catch
        {
            return DateTime.Now;
        }
    }

    public static int GetDateDiff(DateTime date1, DateTime date2)
    {
        try
        {
            int result = 0;
            TimeSpan time;
            time = date1 - date2;

            if (time.Days <= 7)
            {
                result = -7;
            }

            if (time.Days > 7 && time.Days <= 30)
            {
                result = -30;
            }

            if (time.Days > 30 && time.Days <= 60)
            {
                result = -60;
            }

            if (time.Days > 60 && time.Days <= 90)
            {
                result = -90;
            }

            if (time.Days > 90 && time.Days <= 180)
            {
                result = -180;
            }

            if (time.Days > 180 && time.Days <= 365)
            {
                result = -365;
            }

            if (time.Days > 365 && time.Days <= 730)
            {
                result = -730;
            }

            return result;
        }
        catch (Exception)
        {
            return 0;
        }
    }
}
