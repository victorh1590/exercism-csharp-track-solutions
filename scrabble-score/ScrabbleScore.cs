using System;
using System.Collections.Generic;
using System.Linq;

public static class ScrabbleScore
{
    private static HashSet<char> _value1 = new() 
        {'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'};
    private static HashSet<char> _value2 = new() {'D', 'G'};
    private static HashSet<char> _value3 = new() {'B', 'C', 'M', 'P'};
    private static HashSet<char> _value4 = new() 
        {'F', 'H', 'V', 'W', 'Y'};
    private static HashSet<char> _value5 = new() {'K'};
    private static HashSet<char> _value8 = new() {'J', 'X'};
    private static HashSet<char> _value10 = new() {'Q', 'Z'};

    private static int DigitValue(char chr) {
        if (_value1.Contains(chr)) return 1;
        if (_value4.Contains(chr)) return 4;
        if (_value3.Contains(chr)) return 3;
        if (_value2.Contains(chr)) return 2;
        if (_value8.Contains(chr)) return 8;
        if (_value10.Contains(chr)) return 10;
        return _value5.Contains(chr) ? 5 : 0;
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