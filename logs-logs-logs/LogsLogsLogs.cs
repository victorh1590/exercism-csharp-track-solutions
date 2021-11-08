using System;

public enum LogLevel
{
    Unknown = 0,
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42
};

static class LogLine
{
    private static string[] SplitLogComponents(string logLine)
    {
        if (string.IsNullOrEmpty(logLine)) 
            throw new ArgumentException("Invalid log line.");
        
        string[] components = logLine?.Split(":", 2);
        components[0] = components[0].Trim(' ', '[', ']').ToUpperInvariant();
        components[1] = components[1].Trim();
        return components;
    }

    public static LogLevel ParseLogLevel(string logLine)
    {
        string level = SplitLogComponents(logLine)[0];
        return level switch
        {
            "TRC" => LogLevel.Trace,
            "DBG" => LogLevel.Debug,
            "INF" => LogLevel.Info,
            "WRN" => LogLevel.Warning,
            "ERR" => LogLevel.Error,
            "FTL" => LogLevel.Fatal,
            _ => LogLevel.Unknown
        };
    }

    public static string OutputForShortLog(LogLevel logLevel, string message) 
        => $"{(byte)logLevel}:{message}";
}
