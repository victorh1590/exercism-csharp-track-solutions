using System;
using System.Linq;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string log, string delimiter)
        => log.Split(delimiter).Last();

    public static string SubstringBetween(this string log, string openDelimiter, string closeDelimiter)
    {
        return log
            .Split(openDelimiter, 2)
            .Last()
            .Split(closeDelimiter, 2)
            .First();
    }

    public static string Message(this string log)
        => log.SubstringAfter(": ");

    public static string LogLevel(this string log)
        => log.SubstringBetween("[", "]");
}