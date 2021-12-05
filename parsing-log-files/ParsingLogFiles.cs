using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        Regex pattern = new Regex(@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]", RegexOptions.Compiled);
        return pattern.IsMatch(text);
    }

    public string[] SplitLogLine(string text)
    {
        Regex pattern = new Regex(@"\<(\^|\*|\=|\-)*\>", RegexOptions.Compiled);
        MatchCollection matches = pattern.Matches(text);
        IEnumerable<string> delimiters = matches.Select(match => match.ToString());
        return text.Split(delimiters.ToArray(), StringSplitOptions.TrimEntries);
    }

    public int CountQuotedPasswords(string lines)
    {
        Regex pattern = new Regex("\".*(?<pswd>password).*\"", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline);
        int counter = 0;
        foreach(var line in lines.Split('\n'))
        {
            var match = pattern.Match(line);
            if (match.Length > 0 && match.Groups.ContainsKey("pswd")) counter++;
        }

        return counter;
    }

    public string RemoveEndOfLineText(string line)
    {
        Regex pattern = new Regex("(end-of-line)+([0-9])*", RegexOptions.Compiled);
        MatchCollection matches = pattern.Matches(line);
        string[] delimiters = matches.Select(match => match.ToString()).ToArray();
        string[] lineComponents = line.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder sb = new();
        foreach (var component in lineComponents) sb.Append(component);
        return sb.ToString();
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        Regex pattern = new Regex(@"(?<pswd>password+(\w+)?)(?<secret>\s\w*)?");
        // Regex pattern = new Regex(@"(?<pswd>password+(\w+)?)", RegexOptions.IgnoreCase);
        List<string> result = new();
        foreach (var line in lines)
        {
            var match = pattern.Matches(line);
            if (match.Count >= 2)
            {
                result.Add("--------: " + line);
            }
            else
            {
                result.Add(match.First() + ": " + line);
            }
        }

        return result.ToArray();
    }
}
