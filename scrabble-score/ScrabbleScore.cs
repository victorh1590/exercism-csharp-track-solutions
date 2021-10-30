using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static Dictionary<int, HashSet<char>> _scoreTable = new()
    {
        [1] = new HashSet<char> {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'},
        [4] = new HashSet<char> {'F', 'H', 'V', 'W', 'Y'},
        [3] = new HashSet<char> {'B', 'C', 'M', 'P'},
        [2] = new HashSet<char> {'D', 'G'},
        [8] = new HashSet<char> {'J', 'X'},
        [10] = new HashSet<char> {'Q', 'Z'},
        [5] = new HashSet<char> {'K'},
    };
    
    private static int DigitValue(char chr)
    {
        foreach (var (key, set) in _scoreTable)
            if (set.Contains(chr)) return key;
        return 0;
    }
    
    private static int CountCharacter(string input, char chr) => 
        input.Count(c => c == chr);

    public static int Score(string input)
    {
        int sum = 0;
        input = input.ToUpper().Trim();

        while (input.Length > 0)
        {
            sum += (CountCharacter(input, input[0]) * DigitValue(input[0]));
            input = input.Replace(input[0].ToString(), string.Empty);
        }
        return sum;
    }
}