using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        List<string> lines = input.SplitLines().Normalize();
        List<string> transposed = BuildList(lines);
        StringBuilder transposedString = new();
        foreach (string line in lines)
        { 
            for(int index = 0; index < line.Length; index++)
                transposed[index] += line[index];
        }
        foreach (var line in transposed) transposedString.Append(line + '\n');
        return transposedString.Length > 0 ? transposedString.ToString()[..^1] : transposedString.ToString();
    }

    private static List<string> BuildList(List<string> lines)
    {
        List<string> transposed = new();
        for (int line = 0; line < lines.MaxLineWidth(); line++) transposed.Add("");
        return transposed;
    }

    private static List<string> Normalize(this List<string> lines)
    {
        int lastLineLength = lines.Last().Length;
        
        for (int line = lines.Count - 2; line >= 0; line--)
        {
            int currentLineLength = lines[line].Length;
            if (currentLineLength< lastLineLength)
                lines[line] += new string(' ', lastLineLength - currentLineLength);
            else lastLineLength = currentLineLength;
        }
        return lines;
    }
    private static List<string> SplitLines(this string input) => input.Split('\n').ToList();
    private static int MaxLineWidth(this List<string> input) 
        => input.Select(line => line.Length).Prepend(0).Max();
}