using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        List<string> lines = input.SplitLines();
        lines.Normalize();
        List<string> transposed = new();

        int height = lines.Height();
        
        for(int x = 0; x < height; x++) transposed.Add("");
        
        foreach(string line in lines)
        {
            for(int i = 0; i < line.Length; i++)
            {
                transposed[i] += line[i];
            }
        }

        string result = "";
        foreach (var line in transposed)
        {
            result += line;
            result += '\n';
        }

        result = result.Trim(' ');
        return result.Length > 0 ? result[..^1] : result;
    }

    private static List<string> Normalize(this List<string> lines)
    {
        int height = lines.Height();

        int lastLength = lines[0].Length;
        
        for(int i = 0; i < lines.Count; i++)
        {
            if (lines[i].Length < height )
            {
                string spaces = new string(' ', (height - lines[i].Length));
                lines[i] += spaces;
            }
        }

        return lines;
    }

    private static List<string> SplitLines(this string input)
        => input.Split('\n').ToList();

    private static int Height(this List<string> input)
    {
        int max = 0;
        foreach (var line in input)
        {
            if (line.Length > max) max = line.Length;
        }

        return max;
    }
}