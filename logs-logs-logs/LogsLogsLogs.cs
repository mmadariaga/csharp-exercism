using System;

enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,

    Unknown = 0,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string levelShortStr = logLine.Substring(1, 3);
        string levelStr = levelShortStr switch {
            "TRC" => "Trace",
            "DBG" => "Debug",
            "INF" => "Info",
            "WRN" => "Warning",
            "ERR" => "Error",
            "FTL" => "Fatal",
            _ => "UNK"
        };

        if (Enum.TryParse(levelStr, out LogLevel logLevel)) {
            return logLevel;
        }

        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int) logLevel}:{message}";
    }
}
