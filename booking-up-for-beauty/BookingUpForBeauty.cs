using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription) 
        => DateTime.Parse(appointmentDateDescription);

    public static bool HasPassed(DateTime appointmentDate) 
        => appointmentDate.CompareTo(DateTime.Now) < 0;

    public static bool IsAfternoonAppointment(DateTime appointmentDate) 
        => appointmentDate.Hour is >= 12 and < 18;

    public static string Description(DateTime appointmentDate) 
        => $"You have an appointment on {appointmentDate:G}.";

    public static DateTime AnniversaryDate() 
        => new(DateTime.Now.Year, 9, 15, 0, 0, 0);
}
