using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static Dictionary<char, int> _scoreTable = new();
    private static int[] _scores = { 1,4,3,2,8,10,5 };
    private static HashSet<char>[] _groups =
    {
        new() {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'},
        new() {'F', 'H', 'V', 'W', 'Y'},
        new() {'B', 'C', 'M', 'P'},
        new() {'D', 'G'},
        new() {'J', 'X'},
        new() {'Q', 'Z'},
        new() {'K'}
    };

    private static void BuildDictionary()
    {
        int i = 0;
        foreach (var set in _groups)
        {
            foreach (var chr in set)
                _scoreTable[chr] = _scores[i];
            i++;
        }
    }
        
    private static int DigitValue(char chr) => _scoreTable.ContainsKey(chr) ? _scoreTable[chr] : 0;

    private static int CountCharacter(string input, char chr) => input.Count(c => c == chr);

    public static int Score(string input)
    {
        int sum = 0;
        input = input.ToUpper().Trim();
        if(_scoreTable.Count == 0) BuildDictionary();

        while (input.Length > 0)
        {
            sum += CountCharacter(input, input[0]) * DigitValue(input[0]);
            input = input.Replace(input[0].ToString(), string.Empty);
        }
        return sum;
    }
}