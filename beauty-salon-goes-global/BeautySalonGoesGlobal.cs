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
        => TimeZoneInfo.ConvertTimeFromUtc(dtUtc, TimeZoneInfo.Local);
    
    public static DateTime Schedule(string appointmentDateDescription, Location location)
        => GetTimeBasedOnTimeZone(DateTime.Parse(appointmentDateDescription), TimeZoneLocationID(location));

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) 
        => alertLevel switch
        {
            AlertLevel.Early => appointment.AddDays(-1),
            AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
            AlertLevel.Late => appointment.AddMinutes(-30),
            _ => throw new ArgumentOutOfRangeException(nameof(alertLevel), alertLevel, "Invalid alert level.")
        };

    public static bool HasDaylightSavingChanged(DateTime dt, Location location)
    {
        DateTime sevenDaysAgo = dt.AddDays(-7);
        TimeZoneInfo timezone = TimeZoneLocationID(location);
        return timezone.IsDaylightSavingTime(sevenDaysAgo) != timezone.IsDaylightSavingTime(dt);
    }

    public static DateTime NormalizeDateTime(string dtStr, Location location)
    { 
        DateTime date;
        bool ParseDateTimeForCulture()=>
            location switch
            {
                Location.NewYork => DateTime.TryParse(
                    dtStr, new CultureInfo("en-US"), DateTimeStyles.AssumeLocal, out date),
                Location.London => DateTime.TryParse(
                    dtStr, new CultureInfo("en-GB"), DateTimeStyles.AssumeLocal, out date),
                Location.Paris => DateTime.TryParse(
                    dtStr, new CultureInfo("fr-FR"), DateTimeStyles.AssumeLocal, out date),
            };
        return ParseDateTimeForCulture() ? date : DateTime.MinValue;
    }
    
    private static TimeZoneInfo TimeZoneLocationID(Location location)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) 
            return TimeZoneInfo.FindSystemTimeZoneById(WindowsTimeZoneId(location));
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            return TimeZoneInfo.FindSystemTimeZoneById(OSXTimeZoneId(location));
        throw new NotImplementedException("Method not implemented for your platform.");
    }

    private static DateTime GetTimeBasedOnTimeZone(DateTime date, TimeZoneInfo timezone) 
        => TimeZoneInfo.ConvertTimeToUtc(date, timezone);
    
    private static string OSXTimeZoneId (Location location)
        => location switch
        {
            Location.NewYork => "America/New_York",
            Location.London => "Europe/London",
            Location.Paris => "Europe/Paris",
            _ => throw new ArgumentException("Invalid location.")
        };
    
    private static string WindowsTimeZoneId (Location location)
        => location switch
        {
            Location.NewYork => "Eastern Standard Time",
            Location.London => "GMT Standard Time",
            Location.Paris => "W. Europe Standard Time",
            _ => throw new ArgumentException("Invalid location.")
        };
}
