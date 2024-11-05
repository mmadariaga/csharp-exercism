using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        var logSegments = logLine.Split(":");

        return logSegments[1].Trim();
    }

    public static string LogLevel(string logLine)
    {
        var logSegments = logLine.ToLower().Split(":");

        char[] charsToTrim = {'[', ']', ' '};
        return logSegments[0].Trim(charsToTrim);
    }

    public static string Reformat(string logLine)
    {
        var message = Message(logLine);
        var level = LogLevel(logLine);

        return $"{message} ({level})";
    }
}
