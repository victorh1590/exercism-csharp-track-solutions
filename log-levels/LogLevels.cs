using System;
using System.Collections.Generic;

static class LogLine
{
    public static Dictionary<string, string> ParseLogLine(string logLine)
    {
        string[] logLineComponents = logLine.Split(":");
        return new Dictionary<string, string>()
        {
            { "level", logLineComponents[0].Trim('[', ']').ToLower() },
            { "message", logLineComponents[1].Trim() }
        };
    }

    public static string Message(string logLine) => ParseLogLine(logLine)["message"];

    public static string LogLevel(string logLine) => ParseLogLine(logLine)["level"];

    public static string Reformat(string logLine)
    {
        Dictionary<string, string> parsed = ParseLogLine(logLine);
        return $"{parsed["message"]} ({parsed["level"]})";
    }
    
}
