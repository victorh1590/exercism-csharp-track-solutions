using System;
using System.Linq;

public static class Luhn
{
    private static bool ValidFormat(string number)
    {
        if (number == string.Empty) return false;

        int numberCount = 0, zeroCount = 0;
        foreach (char chr in number)
        {
            if (!char.IsNumber(chr))
                return false;
            
            if (chr == '0')
                zeroCount++;
            
            numberCount++;
        }

        return (numberCount > 1 || numberCount > zeroCount);
    }

    private static string RemoveWhitespaces(string number) 
        => string.Join("", number.Trim().Split(' '));

    public static bool IsValid(string number)
    {
        string numberFormatted = RemoveWhitespaces(number);
        
        if (!ValidFormat(numberFormatted)) return false;
        
        int[] numberNumeric = numberFormatted
            .Select(chr => Convert.ToInt32( char.GetNumericValue(chr) ) )
            .ToArray();

        bool secondDigit = false;
        for (int i = numberNumeric.Length - 1; i >= 0; i--)
        {
            if (secondDigit)
            {
                if ((numberNumeric[i] *= 2) > 9) 
                    numberNumeric[i] -= 9;
                secondDigit = false;
                continue;
            }
            secondDigit = true;
        }

        return  ( numberNumeric.Sum() % 10 == 0 );
    }
}