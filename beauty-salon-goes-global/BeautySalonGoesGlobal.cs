using System;
using System.Globalization;
using System.Runtime.InteropServices;

public enum Location
{
    NewYork,
    London,
    Paris
}

public enum AlertLevel
{
    Early,
    Standard,
    Late
}

public static class Appointment
{
    public static DateTime ShowLocalTime(DateTime dtUtc)
    {
        return dtUtc.ToLocalTime();
    }

    public static DateTime Schedule(string appointmentDateDescription, Location location)
    {
        DateTime appointment = DateTime.Parse(appointmentDateDescription);

        return TimeZoneInfo.ConvertTimeToUtc(
            appointment,
            GetTimeZoneInfo(location)
        );
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel)
    {
        var timestan = alertLevel switch {
            AlertLevel.Early => new TimeSpan(1, 0, 0, 0 ),
            AlertLevel.Standard => new TimeSpan(1, 45, 0),
            AlertLevel.Late => new TimeSpan(0, 30, 0),
            _ => throw new ArgumentOutOfRangeException(),
        };

        return appointment - timestan;
    }

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        var timeZoneInfo = GetTimeZoneInfo(location);
        DateTime oneWeekAgo = dt.AddDays(-7);

        return timeZoneInfo.IsDaylightSavingTime(dt) != timeZoneInfo.IsDaylightSavingTime(oneWeekAgo);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    {
        var cultureInfo = GetLocationCultureInfo(location);

        var fallbackDateTime = new DateTime(1, 1, 1);
        bool parseSucceded = DateTime.TryParse(
            dtStr,
            cultureInfo,
            out DateTime response
        );

        return parseSucceded
            ? response
            : fallbackDateTime;
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location)
    {
        bool isOsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        string timeZoneId = location switch
        {
            Location.NewYork => isOsWindows ? "Eastern Standard Time" : "America/New_York",
            Location.London => isOsWindows ? "GMT Standard Time" : "Europe/London",
            Location.Paris => isOsWindows ? "Romance Standard Time" : "Europe/Paris",
            _ => throw new ArgumentOutOfRangeException(),
        };

        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    private static CultureInfo GetLocationCultureInfo(Location location)
    {
        string cultureStr = location switch
        {
            Location.NewYork => "en-US",
            Location.London => "en-GB",
            Location.Paris => "fr-FR",
            _ => throw new ArgumentOutOfRangeException(),
        };

        return CultureInfo.GetCultureInfo(cultureStr);
    }
}
