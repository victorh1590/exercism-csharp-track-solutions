using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        Dictionary<string, int> histogram = new();

        Regex pattern = new Regex(
            @"\b([0-9]||[A-z])(\w|\')+\b", 
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        var matches = pattern
            .Matches(phrase)
            .Select(match => match.ToString().ToLowerInvariant());
        
        foreach (var word in matches)
        {
            if (histogram.ContainsKey(word)) histogram[word]++;
            else histogram.Add(word, 1);
        }

        return histogram;
    }
}