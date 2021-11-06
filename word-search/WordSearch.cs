using System;
using System.Collections.Generic;
using System.Linq;

public class WordSearch
{
    private static List<string> _lines = new();
    private static List<string> _reversedLines = new();
    private static List<string> _columns = new();
    private static List<string> _reversedColumns = new();
    
    public static List<string> GridLines (string grid) 
        => grid.Split('\n').ToList();

    public static void Lines(List<string> grid)
    {
       grid.ForEach(line =>_lines.Add(line));
       grid.ForEach(line => _reversedLines.Add(line.Reverse().ToString()));
    }

    public static void Column(List<string> grid)
    {
        List<string> columns = new();

        for (int col = 0; col < grid.Count; col++)
        {
            columns[col] = new string(string.Empty);
            for (int line = 0; line < grid.Count; line++)
            {
                columns[col] += grid[line][col];
            }
        }
        
        columns.ForEach(line => _columns.Add(line));
        columns.ForEach(line => _reversedColumns.Add(line.Reverse().ToString()));
    }
    
    public static void AscendentDiagonal(List<string> grid)
    {
        List<string> ascendentDiagonal = new();

        for (int col = 0; col < grid.Count; col++)
        {
            ascendentDiagonal[col] = new string(string.Empty);
            for (int line = 0; line < grid.Count; line++)
            {
                ascendentDiagonal[col] += grid[line][col];
            }
        }
        
        ascendentDiagonal.ForEach(line => _columns.Add(line));
        ascendentDiagonal.ForEach(line => _reversedColumns.Add(line.Reverse().ToString()));
    }

    public WordSearch(string grid)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}