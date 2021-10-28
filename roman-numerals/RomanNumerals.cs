using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class RomanNumeralExtension
{
    private static readonly char[] UNIT = {'I', 'V', 'X'};
    private static readonly char[] DEC = {'X', 'L', 'C'};
    private static readonly char[] CENT = {'C', 'D', 'M' };

    private static char[] SelectCharset(int numberOfDigits) =>
        numberOfDigits switch
        {
            4 => new[] {'M'},
            3 => CENT,
            2 => DEC,
            _ => UNIT
        };

    private static string DigitConversion(char digit, IReadOnlyList<char> charset)
    {
        int value = Convert.ToInt32(char.GetNumericValue(digit));
        
        string RepeatChr () => $"{new string(charset[0], value)}";

        if (charset.Count == 1)
            return RepeatChr();

        return value switch
        {
            >= 5 and 9 => $"{charset[0]}{charset[2]}",
            >= 5 => $"{charset[1]}{new string(charset[0], value - 5)}",
            4 => $"{charset[0]}{charset[1]}",
            _ => RepeatChr()
        };
    }
    public static string ToRoman(this int value)
    {
        if (value is > 3999 or < 0)
            throw new ArgumentException("Invalid argument value.");

        StringBuilder romanBuilder = new StringBuilder();
        List<char> digits = value.ToString().ToList();

        while (digits.Count > 0)
        {
            char[] charset = SelectCharset(digits.Count);
            romanBuilder.Append(DigitConversion(digits[0], charset));
            digits.RemoveAt(0);
        }

        return romanBuilder.ToString();
    }
}