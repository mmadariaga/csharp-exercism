using System;

static class Appointment
{
    public static DateTime Schedule(string appointmentDateDescription)
    {
        return DateTime.Parse(appointmentDateDescription);
    }

    public static bool HasPassed(DateTime appointmentDate)
    {
        return appointmentDate < DateTime.Now;
    }

    public static bool IsAfternoonAppointment(DateTime appointmentDate)
    {
        var afternoonStart = new DateTime(2024, 1, 1, 12, 0, 0);
        var afternoonEnd = new DateTime(2024, 1, 1, 12, 0, 0);

        if (appointmentDate.Hour < 12 || appointmentDate.Hour >= 18) {
            return false;
        }

        return true;
    }

    public static string Description(DateTime appointmentDate)
    {
        var dateTimeStr = appointmentDate.ToString("M/d/yyyy h:mm:ss tt.");

        return $"You have an appointment on {dateTimeStr}";
    }

    public static DateTime AnniversaryDate()
    {
        return new DateTime(DateTime.Now.Year, 9, 15, 0, 0, 0);
    }
}
